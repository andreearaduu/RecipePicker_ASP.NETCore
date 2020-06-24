using Microsoft.EntityFrameworkCore.Migrations;

namespace recipePickerApp.Migrations
{
    public partial class migr6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Recipe_RecipeId",
                table: "Reviews");

            migrationBuilder.AlterColumn<long>(
                name: "RecipeId",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Recipe_RecipeId",
                table: "Reviews",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Recipe_RecipeId",
                table: "Reviews");

            migrationBuilder.AlterColumn<long>(
                name: "RecipeId",
                table: "Reviews",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Recipe_RecipeId",
                table: "Reviews",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
