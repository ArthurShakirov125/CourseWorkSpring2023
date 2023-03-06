using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseWorkSpring2023.Data.Migrations
{
    public partial class custom_user_avatar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarImg",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "AvatarImg",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
