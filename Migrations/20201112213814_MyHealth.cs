using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eDoc.Migrations
{
    public partial class MyHealth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyAllergies",
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
                    table.PrimaryKey("PK_MyAllergies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyAllergies_AspNetUsers_UserId",
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

            migrationBuilder.CreateTable(
                name: "MyWeight",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    RecordDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyWeight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyWeight_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyAllergies_UserId",
                table: "MyAllergies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MyBloodPressure_UserId",
                table: "MyBloodPressure",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MyWeight_UserId",
                table: "MyWeight",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyAllergies");

            migrationBuilder.DropTable(
                name: "MyBloodPressure");

            migrationBuilder.DropTable(
                name: "MyWeight");
        }
    }
}
