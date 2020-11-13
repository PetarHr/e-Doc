using Microsoft.EntityFrameworkCore.Migrations;

namespace eDoc.Migrations
{
    public partial class ListNavProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MyWeight_UserId",
                table: "MyWeight");

            migrationBuilder.DropIndex(
                name: "IX_MyBloodPressure_UserId",
                table: "MyBloodPressure");

            migrationBuilder.CreateIndex(
                name: "IX_MyWeight_UserId",
                table: "MyWeight",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MyBloodPressure_UserId",
                table: "MyBloodPressure",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MyWeight_UserId",
                table: "MyWeight");

            migrationBuilder.DropIndex(
                name: "IX_MyBloodPressure_UserId",
                table: "MyBloodPressure");

            migrationBuilder.CreateIndex(
                name: "IX_MyWeight_UserId",
                table: "MyWeight",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MyBloodPressure_UserId",
                table: "MyBloodPressure",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }
    }
}
