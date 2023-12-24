using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportingProject.Migrations
{
    /// <inheritdoc />
    public partial class Update_CountryID_In_ApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Countries_CountryId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "AspNetUsers",
                newName: "CountryID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_CountryId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_CountryID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Countries_CountryID",
                table: "AspNetUsers",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Countries_CountryID",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CountryID",
                table: "AspNetUsers",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_CountryID",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Countries_CountryId",
                table: "AspNetUsers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }
    }
}
