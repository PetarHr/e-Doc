using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eDoc.Migrations
{
    public partial class MyHealthRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyHealthRecords",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    RecordDate = table.Column<DateTime>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    BloodPressure = table.Column<double>(nullable: false),
                    BloodType = table.Column<string>(nullable: true),
                    Allergies = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyHealthRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyHealthRecords_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyHealthRecords_UserId",
                table: "MyHealthRecords",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyHealthRecords");
        }
    }
}
