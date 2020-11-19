using Microsoft.EntityFrameworkCore.Migrations;

namespace eDoc.Migrations
{
    public partial class CountryUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Countries_CountryId1",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CountryId1",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CountryId1",
                table: "Addresses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryId1",
                table: "Addresses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId1",
                table: "Addresses",
                column: "CountryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Countries_CountryId1",
                table: "Addresses",
                column: "CountryId1",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
