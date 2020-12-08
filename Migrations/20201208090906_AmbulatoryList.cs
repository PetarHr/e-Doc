using Microsoft.EntityFrameworkCore.Migrations;

namespace eDoc.Migrations
{
    public partial class AmbulatoryList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NZOКNumber",
                table: "AmbulatoryLists");

            migrationBuilder.RenameColumn(
                name: "SubstituteUIN",
                table: "AmbulatoryLists",
                newName: "NZOKNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NZOKNumber",
                table: "AmbulatoryLists",
                newName: "SubstituteUIN");

            migrationBuilder.AddColumn<string>(
                name: "NZOКNumber",
                table: "AmbulatoryLists",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
