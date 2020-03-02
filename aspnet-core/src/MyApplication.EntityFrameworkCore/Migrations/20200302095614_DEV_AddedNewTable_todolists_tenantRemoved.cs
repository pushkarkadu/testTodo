using Microsoft.EntityFrameworkCore.Migrations;

namespace MyApplication.Migrations
{
    public partial class DEV_AddedNewTable_todolists_tenantRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "tbltodolists");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "tbltodolists",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
