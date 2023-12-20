using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportingProject.Migrations
{
    /// <inheritdoc />
    public partial class Add_One_To_One_Relation_Between_Companies_And_Operators : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Operators",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UniverseInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperatorID = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniverseInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UniverseInvoices_Operators_OperatorID",
                        column: x => x.OperatorID,
                        principalTable: "Operators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operators_CompanyId",
                table: "Operators",
                column: "CompanyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UniverseInvoices_OperatorID",
                table: "UniverseInvoices",
                column: "OperatorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Operators_Companies_CompanyId",
                table: "Operators",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operators_Companies_CompanyId",
                table: "Operators");

            migrationBuilder.DropTable(
                name: "UniverseInvoices");

            migrationBuilder.DropIndex(
                name: "IX_Operators_CompanyId",
                table: "Operators");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Operators");
        }
    }
}
