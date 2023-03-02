using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseWorkSpring2023.Data.Migrations
{
    public partial class litle_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersCommentsRates_Comments_CommentsId",
                table: "UsersCommentsRates");

            migrationBuilder.DropIndex(
                name: "IX_UsersCommentsRates_CommentsId",
                table: "UsersCommentsRates");

            migrationBuilder.DropColumn(
                name: "CommentsId",
                table: "UsersCommentsRates");

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "UsersCommentsRates",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersCommentsRates_CommentId",
                table: "UsersCommentsRates",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCommentsRates_Comments_CommentId",
                table: "UsersCommentsRates",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersCommentsRates_Comments_CommentId",
                table: "UsersCommentsRates");

            migrationBuilder.DropIndex(
                name: "IX_UsersCommentsRates_CommentId",
                table: "UsersCommentsRates");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "UsersCommentsRates");

            migrationBuilder.AddColumn<int>(
                name: "CommentsId",
                table: "UsersCommentsRates",
                type: "int",
                nullable: true);

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
        }
    }
}
