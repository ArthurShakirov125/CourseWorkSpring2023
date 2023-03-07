using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseWorkSpring2023.Data.Migrations
{
    public partial class moderator_stuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "UploadableContent",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "UploadableContent");
        }
    }
}
