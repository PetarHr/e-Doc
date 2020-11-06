using Microsoft.EntityFrameworkCore.Migrations;

namespace eDoc.Migrations
{
    public partial class RecipeMultiCompletion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AllowMultiCompletion",
                table: "Recipes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowMultiCompletion",
                table: "Recipes");
        }
    }
}
