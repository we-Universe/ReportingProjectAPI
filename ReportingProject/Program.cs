using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ReportingProject.Data.Contextes;
using ReportingProject.Data.Entities;
using ReportingProject.Data.Mapping;
using ReportingProject.Repositories.CountryRepository;
using ReportingProject.Repositories.ReportRepository;
using ReportingProject.Repositories.ReportTypeRepository;
using ReportingProject.Services.AuthenticationService;
using ReportingProject.Services.CountryService;
using ReportingProject.Services.ReportService;
using ReportingProject.Services.ReportTypeService;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ReportingDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value);
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 6;
}).AddEntityFrameworkStores<ReportingDBContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        RequireExpirationTime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
        ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value!))

    };
}
);

var allowedOrigin = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowedAppCors", policy =>
    {
        policy.WithOrigins(allowedOrigin!)
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
builder.Services.AddScoped<IReportService,ReportService >();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IReportTypeService, ReportTypeService>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IReportTypeRepository, ReportTypeRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowedAppCors");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
