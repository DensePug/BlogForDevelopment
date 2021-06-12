using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.API.Migrations
{
    public partial class addPreviewContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PreviewContent",
                table: "Posts",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviewContent",
                table: "Posts");
        }
    }
}
