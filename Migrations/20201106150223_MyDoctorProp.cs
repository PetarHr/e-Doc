using Microsoft.EntityFrameworkCore.Migrations;

namespace eDoc.Migrations
{
    public partial class MyDoctorProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MyDoctorId",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyDoctorId",
                table: "AspNetUsers");
        }
    }
}
