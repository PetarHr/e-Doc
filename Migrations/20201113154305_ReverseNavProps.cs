using Microsoft.EntityFrameworkCore.Migrations;

namespace eDoc.Migrations
{
    public partial class ReverseNavProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MyBloodPressure_MyBloodPressureId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MyWeight_MyWeightID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MyBloodPressureId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MyWeightID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MyBloodPressureId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MyWeightID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MyWeight",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MyBloodPressure",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_MyBloodPressure_AspNetUsers_UserId",
                table: "MyBloodPressure",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MyWeight_AspNetUsers_UserId",
                table: "MyWeight",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyBloodPressure_AspNetUsers_UserId",
                table: "MyBloodPressure");

            migrationBuilder.DropForeignKey(
                name: "FK_MyWeight_AspNetUsers_UserId",
                table: "MyWeight");

            migrationBuilder.DropIndex(
                name: "IX_MyWeight_UserId",
                table: "MyWeight");

            migrationBuilder.DropIndex(
                name: "IX_MyBloodPressure_UserId",
                table: "MyBloodPressure");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MyWeight");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MyBloodPressure");

            migrationBuilder.AddColumn<string>(
                name: "MyBloodPressureId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MyWeightID",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MyBloodPressureId",
                table: "AspNetUsers",
                column: "MyBloodPressureId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MyWeightID",
                table: "AspNetUsers",
                column: "MyWeightID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_MyBloodPressure_MyBloodPressureId",
                table: "AspNetUsers",
                column: "MyBloodPressureId",
                principalTable: "MyBloodPressure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_MyWeight_MyWeightID",
                table: "AspNetUsers",
                column: "MyWeightID",
                principalTable: "MyWeight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
