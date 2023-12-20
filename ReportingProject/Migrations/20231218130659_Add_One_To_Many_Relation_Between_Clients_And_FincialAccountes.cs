using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportingProject.Migrations
{
    /// <inheritdoc />
    public partial class Add_One_To_Many_Relation_Between_Clients_And_FincialAccountes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "FinancialAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientRef = table.Column<int>(type: "int", nullable: false),
                    IsBlackListed = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceBillingPeriod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinancialAccounts_ClientID",
                table: "FinancialAccounts",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialAccounts_Clients_ClientID",
                table: "FinancialAccounts",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialAccounts_Clients_ClientID",
                table: "FinancialAccounts");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_FinancialAccounts_ClientID",
                table: "FinancialAccounts");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "FinancialAccounts");
        }
    }
}
