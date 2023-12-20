using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportingProject.Migrations
{
    /// <inheritdoc />
    public partial class Update_Some_Columns : Migration
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
                name: "FK_Contracts_Merchants_MerchantId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialAccounts_Clients_ClientID",
                table: "FinancialAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialAccounts_Countries_CountryID",
                table: "FinancialAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceNotes_Invoices_InvoiceId",
                table: "InvoiceNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_MerchantInvoices_Invoices_InvoiceId",
                table: "MerchantInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_MerchantInvoices_Merchants_MerchantId",
                table: "MerchantInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_MerchantReports_Merchants_MerchantId",
                table: "MerchantReports");

            migrationBuilder.DropForeignKey(
                name: "FK_MerchantReports_Reports_ReportId",
                table: "MerchantReports");

            migrationBuilder.DropForeignKey(
                name: "FK_OperatorReports_Operators_OperatorId",
                table: "OperatorReports");

            migrationBuilder.DropForeignKey(
                name: "FK_OperatorReports_Reports_ReportId",
                table: "OperatorReports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_ReportTypes_ReportTypeId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Contracts_ContractId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ContractId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_OperatorReports_ReportId",
                table: "OperatorReports");

            migrationBuilder.DropIndex(
                name: "IX_MerchantReports_ReportId",
                table: "MerchantReports");

            migrationBuilder.DropIndex(
                name: "IX_MerchantInvoices_InvoiceId",
                table: "MerchantInvoices");

            migrationBuilder.RenameColumn(
                name: "CountryID",
                table: "FinancialAccounts",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "FinancialAccounts",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_FinancialAccounts_CountryID",
                table: "FinancialAccounts",
                newName: "IX_FinancialAccounts_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_FinancialAccounts_ClientID",
                table: "FinancialAccounts",
                newName: "IX_FinancialAccounts_ClientId");

            migrationBuilder.RenameColumn(
                name: "CurrencyID",
                table: "Companies",
                newName: "CurrencyId");

            migrationBuilder.RenameColumn(
                name: "CountryID",
                table: "Companies",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_CurrencyID",
                table: "Companies",
                newName: "IX_Companies_CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_CountryID",
                table: "Companies",
                newName: "IX_Companies_CountryId");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceTypeId",
                table: "Services",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ContractId",
                table: "Services",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ReportTypeId",
                table: "Reports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ReportId",
                table: "OperatorReports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OperatorId",
                table: "OperatorReports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ReportId",
                table: "MerchantReports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MerchantId",
                table: "MerchantReports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MerchantId",
                table: "MerchantInvoices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "MerchantInvoices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "InvoiceNotes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MerchantId",
                table: "Contracts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ContractId",
                table: "Services",
                column: "ContractId",
                unique: true,
                filter: "[ContractId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorReports_ReportId",
                table: "OperatorReports",
                column: "ReportId",
                unique: true,
                filter: "[ReportId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MerchantReports_ReportId",
                table: "MerchantReports",
                column: "ReportId",
                unique: true,
                filter: "[ReportId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MerchantInvoices_InvoiceId",
                table: "MerchantInvoices",
                column: "InvoiceId",
                unique: true,
                filter: "[InvoiceId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Countries_CountryId",
                table: "Companies",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Currencies_CurrencyId",
                table: "Companies",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Merchants_MerchantId",
                table: "Contracts",
                column: "MerchantId",
                principalTable: "Merchants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialAccounts_Clients_ClientId",
                table: "FinancialAccounts",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialAccounts_Countries_CountryId",
                table: "FinancialAccounts",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceNotes_Invoices_InvoiceId",
                table: "InvoiceNotes",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MerchantInvoices_Invoices_InvoiceId",
                table: "MerchantInvoices",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MerchantInvoices_Merchants_MerchantId",
                table: "MerchantInvoices",
                column: "MerchantId",
                principalTable: "Merchants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MerchantReports_Merchants_MerchantId",
                table: "MerchantReports",
                column: "MerchantId",
                principalTable: "Merchants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MerchantReports_Reports_ReportId",
                table: "MerchantReports",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OperatorReports_Operators_OperatorId",
                table: "OperatorReports",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OperatorReports_Reports_ReportId",
                table: "OperatorReports",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_ReportTypes_ReportTypeId",
                table: "Reports",
                column: "ReportTypeId",
                principalTable: "ReportTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Contracts_ContractId",
                table: "Services",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Countries_CountryId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Currencies_CurrencyId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Merchants_MerchantId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialAccounts_Clients_ClientId",
                table: "FinancialAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialAccounts_Countries_CountryId",
                table: "FinancialAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceNotes_Invoices_InvoiceId",
                table: "InvoiceNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_MerchantInvoices_Invoices_InvoiceId",
                table: "MerchantInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_MerchantInvoices_Merchants_MerchantId",
                table: "MerchantInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_MerchantReports_Merchants_MerchantId",
                table: "MerchantReports");

            migrationBuilder.DropForeignKey(
                name: "FK_MerchantReports_Reports_ReportId",
                table: "MerchantReports");

            migrationBuilder.DropForeignKey(
                name: "FK_OperatorReports_Operators_OperatorId",
                table: "OperatorReports");

            migrationBuilder.DropForeignKey(
                name: "FK_OperatorReports_Reports_ReportId",
                table: "OperatorReports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_ReportTypes_ReportTypeId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Contracts_ContractId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ContractId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_OperatorReports_ReportId",
                table: "OperatorReports");

            migrationBuilder.DropIndex(
                name: "IX_MerchantReports_ReportId",
                table: "MerchantReports");

            migrationBuilder.DropIndex(
                name: "IX_MerchantInvoices_InvoiceId",
                table: "MerchantInvoices");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "FinancialAccounts",
                newName: "CountryID");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "FinancialAccounts",
                newName: "ClientID");

            migrationBuilder.RenameIndex(
                name: "IX_FinancialAccounts_CountryId",
                table: "FinancialAccounts",
                newName: "IX_FinancialAccounts_CountryID");

            migrationBuilder.RenameIndex(
                name: "IX_FinancialAccounts_ClientId",
                table: "FinancialAccounts",
                newName: "IX_FinancialAccounts_ClientID");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "Companies",
                newName: "CurrencyID");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Companies",
                newName: "CountryID");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_CurrencyId",
                table: "Companies",
                newName: "IX_Companies_CurrencyID");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_CountryId",
                table: "Companies",
                newName: "IX_Companies_CountryID");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceTypeId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ContractId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReportTypeId",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReportId",
                table: "OperatorReports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OperatorId",
                table: "OperatorReports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReportId",
                table: "MerchantReports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MerchantId",
                table: "MerchantReports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MerchantId",
                table: "MerchantInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "MerchantInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "InvoiceNotes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MerchantId",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_ContractId",
                table: "Services",
                column: "ContractId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperatorReports_ReportId",
                table: "OperatorReports",
                column: "ReportId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MerchantReports_ReportId",
                table: "MerchantReports",
                column: "ReportId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MerchantInvoices_InvoiceId",
                table: "MerchantInvoices",
                column: "InvoiceId",
                unique: true);

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
                name: "FK_Contracts_Merchants_MerchantId",
                table: "Contracts",
                column: "MerchantId",
                principalTable: "Merchants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_InvoiceNotes_Invoices_InvoiceId",
                table: "InvoiceNotes",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MerchantInvoices_Invoices_InvoiceId",
                table: "MerchantInvoices",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MerchantInvoices_Merchants_MerchantId",
                table: "MerchantInvoices",
                column: "MerchantId",
                principalTable: "Merchants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MerchantReports_Merchants_MerchantId",
                table: "MerchantReports",
                column: "MerchantId",
                principalTable: "Merchants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MerchantReports_Reports_ReportId",
                table: "MerchantReports",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OperatorReports_Operators_OperatorId",
                table: "OperatorReports",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OperatorReports_Reports_ReportId",
                table: "OperatorReports",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_ReportTypes_ReportTypeId",
                table: "Reports",
                column: "ReportTypeId",
                principalTable: "ReportTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Contracts_ContractId",
                table: "Services",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
