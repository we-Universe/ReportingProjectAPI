using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportingProject.Migrations
{
    /// <inheritdoc />
    public partial class Add_InvoiceFile_Column_In_Invoices_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Reports");

            migrationBuilder.AddColumn<byte[]>(
                name: "InvoiceFile",
                table: "Invoices",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceFile",
                table: "Invoices");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
