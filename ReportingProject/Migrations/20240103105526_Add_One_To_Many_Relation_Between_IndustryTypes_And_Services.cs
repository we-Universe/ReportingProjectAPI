using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportingProject.Migrations
{
    /// <inheritdoc />
    public partial class Add_One_To_Many_Relation_Between_IndustryTypes_And_Services : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Merchants_IndustryTypes_IndustryTypeId",
                table: "Merchants");

            migrationBuilder.DropIndex(
                name: "IX_Merchants_IndustryTypeId",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "IndustryTypeId",
                table: "Merchants");

            migrationBuilder.AddColumn<int>(
                name: "IndustryTypeId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContractRef",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Services_IndustryTypeId",
                table: "Services",
                column: "IndustryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_IndustryTypes_IndustryTypeId",
                table: "Services",
                column: "IndustryTypeId",
                principalTable: "IndustryTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_IndustryTypes_IndustryTypeId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_IndustryTypeId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "IndustryTypeId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ContractRef",
                table: "Contracts");

            migrationBuilder.AddColumn<int>(
                name: "IndustryTypeId",
                table: "Merchants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_IndustryTypeId",
                table: "Merchants",
                column: "IndustryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Merchants_IndustryTypes_IndustryTypeId",
                table: "Merchants",
                column: "IndustryTypeId",
                principalTable: "IndustryTypes",
                principalColumn: "Id");
        }
    }
}
