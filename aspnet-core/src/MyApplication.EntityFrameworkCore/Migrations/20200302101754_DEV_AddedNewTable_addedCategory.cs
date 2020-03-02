using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyApplication.Migrations
{
    public partial class DEV_AddedNewTable_addedCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "tbltodolists");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "tbltodolists",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "tbltodolists");

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "tbltodolists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
