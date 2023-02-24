using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseWorkSpring2023.Data.Migrations
{
    public partial class update_ratings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UsersPostsRates",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UsersCommentsRates",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersPostsRates",
                table: "UsersPostsRates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersCommentsRates",
                table: "UsersCommentsRates",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersPostsRates",
                table: "UsersPostsRates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersCommentsRates",
                table: "UsersCommentsRates");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UsersPostsRates");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UsersCommentsRates");
        }
    }
}
