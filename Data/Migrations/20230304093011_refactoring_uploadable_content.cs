using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseWorkSpring2023.Data.Migrations
{
    public partial class refactoring_uploadable_content : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Posts_PostId",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "UsersCommentsRates");

            migrationBuilder.DropTable(
                name: "UsersPostsRates");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Posted",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "UploadableContent");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_UserId",
                table: "UploadableContent",
                newName: "IX_UploadableContent_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "UploadableContent",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Uploaded",
                table: "UploadableContent",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "UploadableContent",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Post_Text",
                table: "UploadableContent",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Post_UserId",
                table: "UploadableContent",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UploadableContent",
                table: "UploadableContent",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomUserId = table.Column<string>(nullable: true),
                    ContentId = table.Column<int>(nullable: true),
                    isUpvote = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rates_UploadableContent_ContentId",
                        column: x => x.ContentId,
                        principalTable: "UploadableContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rates_AspNetUsers_CustomUserId",
                        column: x => x.CustomUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UploadableContent_PostId",
                table: "UploadableContent",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadableContent_Post_UserId",
                table: "UploadableContent",
                column: "Post_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_ContentId",
                table: "Rates",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_CustomUserId",
                table: "Rates",
                column: "CustomUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_UploadableContent_PostId",
                table: "Tags",
                column: "PostId",
                principalTable: "UploadableContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UploadableContent_UploadableContent_PostId",
                table: "UploadableContent",
                column: "PostId",
                principalTable: "UploadableContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UploadableContent_AspNetUsers_UserId",
                table: "UploadableContent",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UploadableContent_AspNetUsers_Post_UserId",
                table: "UploadableContent",
                column: "Post_UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_UploadableContent_PostId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_UploadableContent_UploadableContent_PostId",
                table: "UploadableContent");

            migrationBuilder.DropForeignKey(
                name: "FK_UploadableContent_AspNetUsers_UserId",
                table: "UploadableContent");

            migrationBuilder.DropForeignKey(
                name: "FK_UploadableContent_AspNetUsers_Post_UserId",
                table: "UploadableContent");

            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UploadableContent",
                table: "UploadableContent");

            migrationBuilder.DropIndex(
                name: "IX_UploadableContent_PostId",
                table: "UploadableContent");

            migrationBuilder.DropIndex(
                name: "IX_UploadableContent_Post_UserId",
                table: "UploadableContent");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "UploadableContent");

            migrationBuilder.DropColumn(
                name: "Uploaded",
                table: "UploadableContent");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "UploadableContent");

            migrationBuilder.DropColumn(
                name: "Post_Text",
                table: "UploadableContent");

            migrationBuilder.DropColumn(
                name: "Post_UserId",
                table: "UploadableContent");

            migrationBuilder.RenameTable(
                name: "UploadableContent",
                newName: "Posts");

            migrationBuilder.RenameIndex(
                name: "IX_UploadableContent_UserId",
                table: "Posts",
                newName: "IX_Posts_UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Posted",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentatorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Commented = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Downvotes = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Upvotes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_CommentatorId",
                        column: x => x.CommentatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersPostsRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    isUpvote = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPostsRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersPostsRates_AspNetUsers_CustomUserId",
                        column: x => x.CustomUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersPostsRates_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersCommentsRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentId = table.Column<int>(type: "int", nullable: true),
                    CustomUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    isUpvote = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersCommentsRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersCommentsRates_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersCommentsRates_AspNetUsers_CustomUserId",
                        column: x => x.CustomUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentatorId",
                table: "Comments",
                column: "CommentatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCommentsRates_CommentId",
                table: "UsersCommentsRates",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCommentsRates_CustomUserId",
                table: "UsersCommentsRates",
                column: "CustomUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPostsRates_CustomUserId",
                table: "UsersPostsRates",
                column: "CustomUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPostsRates_PostId",
                table: "UsersPostsRates",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Posts_PostId",
                table: "Tags",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
