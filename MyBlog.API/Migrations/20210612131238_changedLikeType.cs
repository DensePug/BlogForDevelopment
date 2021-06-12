using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.API.Migrations
{
    public partial class changedLikeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<List<long>>(
                name: "DateLoggedInUserLiked",
                table: "Posts",
                type: "bigint[]",
                nullable: true,
                oldClrType: typeof(int[]),
                oldType: "integer[]",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int[]>(
                name: "DateLoggedInUserLiked",
                table: "Posts",
                type: "integer[]",
                nullable: true,
                oldClrType: typeof(List<long>),
                oldType: "bigint[]",
                oldNullable: true);
        }
    }
}
