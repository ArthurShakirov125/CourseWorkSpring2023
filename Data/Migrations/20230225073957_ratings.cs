using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseWorkSpring2023.Data.Migrations
{
    public partial class ratings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isUpvote",
                table: "UsersPostsRates",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isUpvote",
                table: "UsersPostsRates");
        }
    }
}
