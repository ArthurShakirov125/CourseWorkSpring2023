using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseWorkSpring2023.Data.Migrations
{
    public partial class fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_CustomUserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CustomUserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CustomUserId",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "CustomUserId",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CustomUserId",
                table: "Posts",
                column: "CustomUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_CustomUserId",
                table: "Posts",
                column: "CustomUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
