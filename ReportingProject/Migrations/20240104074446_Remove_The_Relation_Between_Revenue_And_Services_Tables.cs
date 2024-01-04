using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportingProject.Migrations
{
    /// <inheritdoc />
    public partial class Remove_The_Relation_Between_Revenue_And_Services_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Revenues_Services_ServiceId",
                table: "Revenues");

            migrationBuilder.DropIndex(
                name: "IX_Revenues_ServiceId",
                table: "Revenues");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Revenues");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Revenues",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Revenues_ServiceId",
                table: "Revenues",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Revenues_Services_ServiceId",
                table: "Revenues",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }
    }
}
