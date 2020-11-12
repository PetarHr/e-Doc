using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eDoc.Migrations
{
    public partial class MyWeight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_MyWeight_UserId",
                table: "MyWeight",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyWeight");
        }
    }
}
