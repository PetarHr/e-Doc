using Microsoft.EntityFrameworkCore.Migrations;

namespace eDoc.Migrations
{
    public partial class NZOK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NZONNumber",
                table: "AmbulatoryLists",
                newName: "NZOКNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NZOКNumber",
                table: "AmbulatoryLists",
                newName: "NZONNumber");
        }
    }
}
