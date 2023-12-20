using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportingProject.Migrations
{
    /// <inheritdoc />
    public partial class Update_Some_Entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MerchantInvoices_ApprovalStatuses_ApprovalStatusId",
                table: "MerchantInvoices");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Revenues",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "ShortCode",
                table: "ServiceOperators",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ApprovalStatusId",
                table: "MerchantInvoices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ISOCode",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_MerchantInvoices_ApprovalStatuses_ApprovalStatusId",
                table: "MerchantInvoices",
                column: "ApprovalStatusId",
                principalTable: "ApprovalStatuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MerchantInvoices_ApprovalStatuses_ApprovalStatusId",
                table: "MerchantInvoices");

            migrationBuilder.DropColumn(
                name: "ISOCode",
                table: "Countries");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Revenues",
                newName: "ID");

            migrationBuilder.AlterColumn<int>(
                name: "ShortCode",
                table: "ServiceOperators",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApprovalStatusId",
                table: "MerchantInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MerchantInvoices_ApprovalStatuses_ApprovalStatusId",
                table: "MerchantInvoices",
                column: "ApprovalStatusId",
                principalTable: "ApprovalStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
