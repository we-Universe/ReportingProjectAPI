using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportingProject.Migrations
{
    /// <inheritdoc />
    public partial class Add_ConsultantShare_Column_In_Services_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ConsultantShare",
                table: "Services",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsultantShare",
                table: "Services");
        }
    }
}
