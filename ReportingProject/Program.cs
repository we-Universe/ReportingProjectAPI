using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ReportingProject.Data.Contextes;
using ReportingProject.Data.Entities;
using ReportingProject.Repositories.OperatorReportRepository;
using ReportingProject.Data.Mapping;
using ReportingProject.Repositories.CountryRepository;
using ReportingProject.Repositories.ReportRepository;
using ReportingProject.Repositories.ReportTypeRepository;
using ReportingProject.Services.AuthenticationService;
using ReportingProject.Services.CountryService;
using ReportingProject.Services.OperatorReportService;
using ReportingProject.Services.ReportService;
using ReportingProject.Services.ReportTypeService;
using System.Text;
using ReportingProject.Services.InvoiceService;
using ReportingProject.Repositories.InvoiceRepository;
using ReportingProject.Repositories.ApprovalStatusesRepository;
using ReportingProject.Services.ApprovalStatusesService;
using ReportingProject.Services.OperatorService;
using ReportingProject.Repositories.OperatorRepository;
using ReportingProject.Repositories.MerchantReportRepository;
using ReportingProject.Repositories.ContractRepository;
using ReportingProject.Services.ContractService;
using ReportingProject.Services.MerchantService;
using ReportingProject.Repositories.MerchantRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ReportingDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value);
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 6;
    options.User.RequireUniqueEmail = true;
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
builder.Services.AddScoped<IOperatorReportService, OperatorReportService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IReportTypeService, ReportTypeService>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IReportTypeRepository, ReportTypeRepository>();
builder.Services.AddScoped<IOperatorReportRepository, OperatorReportRepository>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IApprovalStatusesService, ApprovalStatusesService>();
builder.Services.AddScoped<IApprovalStatusesRepository, ApprovalStatusesRepository>();
builder.Services.AddScoped<IOperatorService, OperatorService>();
builder.Services.AddScoped<IOperatorRepository, OperatorRepository>();
builder.Services.AddScoped<IMerchantReportRepository, MerchantReportRepository>();
builder.Services.AddScoped<IContractService, ContractService>();
builder.Services.AddScoped<IContractRepository, ContractRepository>();
builder.Services.AddScoped<IMerchantService, MerchantService>();
builder.Services.AddScoped<IMerchantRepository, MerchantRepository>();

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
