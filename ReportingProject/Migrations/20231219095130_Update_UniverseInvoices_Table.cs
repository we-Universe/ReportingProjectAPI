using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportingProject.Migrations
{
    /// <inheritdoc />
    public partial class Update_UniverseInvoices_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UniverseInvoices_Operators_OperatorID",
                table: "UniverseInvoices");

            migrationBuilder.RenameColumn(
                name: "OperatorID",
                table: "UniverseInvoices",
                newName: "OperatorId");

            migrationBuilder.RenameIndex(
                name: "IX_UniverseInvoices_OperatorID",
                table: "UniverseInvoices",
                newName: "IX_UniverseInvoices_OperatorId");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "UniverseInvoices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UniverseInvoices_InvoiceId",
                table: "UniverseInvoices",
                column: "InvoiceId",
                unique: true,
                filter: "[InvoiceId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UniverseInvoices_Invoices_InvoiceId",
                table: "UniverseInvoices",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_UniverseInvoices_Operators_OperatorId",
                table: "UniverseInvoices",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UniverseInvoices_Invoices_InvoiceId",
                table: "UniverseInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_UniverseInvoices_Operators_OperatorId",
                table: "UniverseInvoices");

            migrationBuilder.DropIndex(
                name: "IX_UniverseInvoices_InvoiceId",
                table: "UniverseInvoices");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "UniverseInvoices");

            migrationBuilder.RenameColumn(
                name: "OperatorId",
                table: "UniverseInvoices",
                newName: "OperatorID");

            migrationBuilder.RenameIndex(
                name: "IX_UniverseInvoices_OperatorId",
                table: "UniverseInvoices",
                newName: "IX_UniverseInvoices_OperatorID");

            migrationBuilder.AddForeignKey(
                name: "FK_UniverseInvoices_Operators_OperatorID",
                table: "UniverseInvoices",
                column: "OperatorID",
                principalTable: "Operators",
                principalColumn: "Id");
        }
    }
}
