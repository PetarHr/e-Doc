using Microsoft.EntityFrameworkCore.Migrations;

namespace eDoc.Migrations
{
    public partial class RecipeCompleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Recipes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Recipes");
        }
    }
}
