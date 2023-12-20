using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportingProject.Migrations
{
    /// <inheritdoc />
    public partial class Add_One_To_Many_Realtaion_Between_ServiceOperator_And_ServiceStatus_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusID",
                table: "ServiceOperators");

            migrationBuilder.AddColumn<int>(
                name: "ServiceStatusId",
                table: "ServiceOperators",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOperators_ServiceStatusId",
                table: "ServiceOperators",
                column: "ServiceStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOperators_ServiceStatuses_ServiceStatusId",
                table: "ServiceOperators",
                column: "ServiceStatusId",
                principalTable: "ServiceStatuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOperators_ServiceStatuses_ServiceStatusId",
                table: "ServiceOperators");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOperators_ServiceStatusId",
                table: "ServiceOperators");

            migrationBuilder.DropColumn(
                name: "ServiceStatusId",
                table: "ServiceOperators");

            migrationBuilder.AddColumn<int>(
                name: "StatusID",
                table: "ServiceOperators",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
