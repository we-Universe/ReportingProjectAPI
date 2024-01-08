using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportingProject.Migrations
{
    /// <inheritdoc />
    public partial class Add_Realtion_One_To_Many_Between_Revenues_And_ServiceOperators_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOperators_Operators_OperatorId",
                table: "ServiceOperators");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOperators_Services_ServiceId",
                table: "ServiceOperators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceOperators",
                table: "ServiceOperators");

            migrationBuilder.AlterColumn<int>(
                name: "OperatorId",
                table: "ServiceOperators",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "ServiceOperators",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ServiceOperators",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ServiceOperatorId",
                table: "Revenues",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceOperators",
                table: "ServiceOperators",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOperators_ServiceId",
                table: "ServiceOperators",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Revenues_ServiceOperatorId",
                table: "Revenues",
                column: "ServiceOperatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Revenues_ServiceOperators_ServiceOperatorId",
                table: "Revenues",
                column: "ServiceOperatorId",
                principalTable: "ServiceOperators",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOperators_Operators_OperatorId",
                table: "ServiceOperators",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOperators_Services_ServiceId",
                table: "ServiceOperators",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Revenues_ServiceOperators_ServiceOperatorId",
                table: "Revenues");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOperators_Operators_OperatorId",
                table: "ServiceOperators");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOperators_Services_ServiceId",
                table: "ServiceOperators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceOperators",
                table: "ServiceOperators");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOperators_ServiceId",
                table: "ServiceOperators");

            migrationBuilder.DropIndex(
                name: "IX_Revenues_ServiceOperatorId",
                table: "Revenues");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ServiceOperators");

            migrationBuilder.DropColumn(
                name: "ServiceOperatorId",
                table: "Revenues");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "ServiceOperators",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OperatorId",
                table: "ServiceOperators",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceOperators",
                table: "ServiceOperators",
                columns: new[] { "ServiceId", "OperatorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOperators_Operators_OperatorId",
                table: "ServiceOperators",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOperators_Services_ServiceId",
                table: "ServiceOperators",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
