using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportingProject.Migrations
{
    /// <inheritdoc />
    public partial class Update_Ids_To_Be_Nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Countries_CountryID",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Currencies_CurrencyID",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyEmails_Companies_CompanyId",
                table: "CompanyEmails");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialAccounts_Clients_ClientID",
                table: "FinancialAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialAccounts_Countries_CountryID",
                table: "FinancialAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Operators_Companies_CompanyId",
                table: "Operators");

            migrationBuilder.DropForeignKey(
                name: "FK_UniverseInvoices_Operators_OperatorID",
                table: "UniverseInvoices");

            migrationBuilder.DropIndex(
                name: "IX_Operators_CompanyId",
                table: "Operators");

            migrationBuilder.AlterColumn<int>(
                name: "OperatorID",
                table: "UniverseInvoices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Operators",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CountryID",
                table: "FinancialAccounts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "FinancialAccounts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "CompanyEmails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyID",
                table: "Companies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CountryID",
                table: "Companies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Operators_CompanyId",
                table: "Operators",
                column: "CompanyId",
                unique: true,
                filter: "[CompanyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CompanyId",
                table: "Clients",
                column: "CompanyId",
                unique: true,
                filter: "[CompanyId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Companies_CompanyId",
                table: "Clients",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Countries_CountryID",
                table: "Companies",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Currencies_CurrencyID",
                table: "Companies",
                column: "CurrencyID",
                principalTable: "Currencies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyEmails_Companies_CompanyId",
                table: "CompanyEmails",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialAccounts_Clients_ClientID",
                table: "FinancialAccounts",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialAccounts_Countries_CountryID",
                table: "FinancialAccounts",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Operators_Companies_CompanyId",
                table: "Operators",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UniverseInvoices_Operators_OperatorID",
                table: "UniverseInvoices",
                column: "OperatorID",
                principalTable: "Operators",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Companies_CompanyId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Countries_CountryID",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Currencies_CurrencyID",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyEmails_Companies_CompanyId",
                table: "CompanyEmails");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialAccounts_Clients_ClientID",
                table: "FinancialAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialAccounts_Countries_CountryID",
                table: "FinancialAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Operators_Companies_CompanyId",
                table: "Operators");

            migrationBuilder.DropForeignKey(
                name: "FK_UniverseInvoices_Operators_OperatorID",
                table: "UniverseInvoices");

            migrationBuilder.DropIndex(
                name: "IX_Operators_CompanyId",
                table: "Operators");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CompanyId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Clients");

            migrationBuilder.AlterColumn<int>(
                name: "OperatorID",
                table: "UniverseInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Operators",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryID",
                table: "FinancialAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "FinancialAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "CompanyEmails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyID",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryID",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Operators_CompanyId",
                table: "Operators",
                column: "CompanyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Countries_CountryID",
                table: "Companies",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Currencies_CurrencyID",
                table: "Companies",
                column: "CurrencyID",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyEmails_Companies_CompanyId",
                table: "CompanyEmails",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialAccounts_Clients_ClientID",
                table: "FinancialAccounts",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialAccounts_Countries_CountryID",
                table: "FinancialAccounts",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Operators_Companies_CompanyId",
                table: "Operators",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UniverseInvoices_Operators_OperatorID",
                table: "UniverseInvoices",
                column: "OperatorID",
                principalTable: "Operators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
