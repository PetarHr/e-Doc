using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eDoc.Migrations
{
    public partial class MyHealth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergy",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DiscoveredOn = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allergy_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MyBloodPressure",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Systolic = table.Column<double>(nullable: false),
                    Diastolic = table.Column<double>(nullable: false),
                    RecordDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyBloodPressure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyBloodPressure_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allergy_UserId",
                table: "Allergy",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MyBloodPressure_UserId",
                table: "MyBloodPressure",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergy");

            migrationBuilder.DropTable(
                name: "MyBloodPressure");
        }
    }
}
