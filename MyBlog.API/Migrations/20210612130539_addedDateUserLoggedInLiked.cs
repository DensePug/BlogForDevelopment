using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.API.Migrations
{
    public partial class addedDateUserLoggedInLiked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int[]>(
                name: "DateLoggedInUserLiked",
                table: "Posts",
                type: "integer[]",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateLoggedInUserLiked",
                table: "Posts");
        }
    }
}
