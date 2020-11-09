using Microsoft.EntityFrameworkCore.Migrations;

namespace eDoc.Migrations
{
    public partial class TypoInAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Specialtycode",
                table: "AspNetUsers",
                newName: "SpecialtyCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SpecialtyCode",
                table: "AspNetUsers",
                newName: "Specialtycode");
        }
    }
}
