using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseWorkSpring2023.Data.Migrations
{
    public partial class comments_and_ratings2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "UsersPostsRates",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommentsId",
                table: "UsersCommentsRates",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersPostsRates_PostId",
                table: "UsersPostsRates",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCommentsRates_CommentsId",
                table: "UsersCommentsRates",
                column: "CommentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCommentsRates_Comments_CommentsId",
                table: "UsersCommentsRates",
                column: "CommentsId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersPostsRates_Posts_PostId",
                table: "UsersPostsRates",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersCommentsRates_Comments_CommentsId",
                table: "UsersCommentsRates");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersPostsRates_Posts_PostId",
                table: "UsersPostsRates");

            migrationBuilder.DropIndex(
                name: "IX_UsersPostsRates_PostId",
                table: "UsersPostsRates");

            migrationBuilder.DropIndex(
                name: "IX_UsersCommentsRates_CommentsId",
                table: "UsersCommentsRates");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "UsersPostsRates");

            migrationBuilder.DropColumn(
                name: "CommentsId",
                table: "UsersCommentsRates");
        }
    }
}
