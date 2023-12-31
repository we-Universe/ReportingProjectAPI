using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportingProject.Migrations
{
    /// <inheritdoc />
    public partial class Update_MerchantTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Merchants_Employees_EmployeeID",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "EmloyeeId",
                table: "Merchants");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Merchants",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Merchants_EmployeeID",
                table: "Merchants",
                newName: "IX_Merchants_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Merchants_Employees_EmployeeId",
                table: "Merchants",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Merchants_Employees_EmployeeId",
                table: "Merchants");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Merchants",
                newName: "EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_Merchants_EmployeeId",
                table: "Merchants",
                newName: "IX_Merchants_EmployeeID");

            migrationBuilder.AddColumn<int>(
                name: "EmloyeeId",
                table: "Merchants",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Merchants_Employees_EmployeeID",
                table: "Merchants",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID");
        }
    }
}
