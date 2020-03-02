using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyApplication.Migrations
{
    public partial class DEV_AddedNewTable_todolists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpPermissions_AbpRoles_RoleId",
                table: "AbpPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpPermissions_AbpUsers_UserId",
                table: "AbpPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpRoleClaims_AbpRoles_RoleId",
                table: "AbpRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpRoles_AbpUsers_CreatorUserId",
                table: "AbpRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpRoles_AbpUsers_DeleterUserId",
                table: "AbpRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpRoles_AbpUsers_LastModifierUserId",
                table: "AbpRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpSettings_AbpUsers_UserId",
                table: "AbpSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpTenants_AbpUsers_CreatorUserId",
                table: "AbpTenants");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpTenants_AbpUsers_DeleterUserId",
                table: "AbpTenants");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpTenants_AbpUsers_LastModifierUserId",
                table: "AbpTenants");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUserClaims_AbpUsers_UserId",
                table: "AbpUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUserLogins_AbpUsers_UserId",
                table: "AbpUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUserRoles_AbpUsers_UserId",
                table: "AbpUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_AbpUsers_CreatorUserId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_AbpUsers_DeleterUserId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_AbpUsers_LastModifierUserId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUserTokens_AbpUsers_UserId",
                table: "AbpUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AbpUsers",
                table: "AbpUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AbpRoles",
                table: "AbpRoles");

            migrationBuilder.RenameTable(
                name: "AbpUsers",
                newName: "tsyusers");

            migrationBuilder.RenameTable(
                name: "AbpRoles",
                newName: "tsyroles");

            migrationBuilder.RenameIndex(
                name: "IX_AbpUsers_TenantId_NormalizedUserName",
                table: "tsyusers",
                newName: "IX_tsyusers_TenantId_NormalizedUserName");

            migrationBuilder.RenameIndex(
                name: "IX_AbpUsers_TenantId_NormalizedEmailAddress",
                table: "tsyusers",
                newName: "IX_tsyusers_TenantId_NormalizedEmailAddress");

            migrationBuilder.RenameIndex(
                name: "IX_AbpUsers_LastModifierUserId",
                table: "tsyusers",
                newName: "IX_tsyusers_LastModifierUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AbpUsers_DeleterUserId",
                table: "tsyusers",
                newName: "IX_tsyusers_DeleterUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AbpUsers_CreatorUserId",
                table: "tsyusers",
                newName: "IX_tsyusers_CreatorUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AbpRoles_TenantId_NormalizedName",
                table: "tsyroles",
                newName: "IX_tsyroles_TenantId_NormalizedName");

            migrationBuilder.RenameIndex(
                name: "IX_AbpRoles_LastModifierUserId",
                table: "tsyroles",
                newName: "IX_tsyroles_LastModifierUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AbpRoles_DeleterUserId",
                table: "tsyroles",
                newName: "IX_tsyroles_DeleterUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AbpRoles_CreatorUserId",
                table: "tsyroles",
                newName: "IX_tsyroles_CreatorUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tsyusers",
                table: "tsyusers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tsyroles",
                table: "tsyroles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "tbltodolists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TaskName = table.Column<string>(nullable: true),
                    Desciption = table.Column<string>(nullable: true),
                    IsCompleted = table.Column<bool>(nullable: false),
                    Deadline = table.Column<DateTime>(nullable: false),
                    CompletedOn = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbltodolists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbltodolists_tsyusers_UserId",
                        column: x => x.UserId,
                        principalTable: "tsyusers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbltodolists_UserId",
                table: "tbltodolists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpPermissions_tsyroles_RoleId",
                table: "AbpPermissions",
                column: "RoleId",
                principalTable: "tsyroles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpPermissions_tsyusers_UserId",
                table: "AbpPermissions",
                column: "UserId",
                principalTable: "tsyusers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpRoleClaims_tsyroles_RoleId",
                table: "AbpRoleClaims",
                column: "RoleId",
                principalTable: "tsyroles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpSettings_tsyusers_UserId",
                table: "AbpSettings",
                column: "UserId",
                principalTable: "tsyusers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpTenants_tsyusers_CreatorUserId",
                table: "AbpTenants",
                column: "CreatorUserId",
                principalTable: "tsyusers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpTenants_tsyusers_DeleterUserId",
                table: "AbpTenants",
                column: "DeleterUserId",
                principalTable: "tsyusers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpTenants_tsyusers_LastModifierUserId",
                table: "AbpTenants",
                column: "LastModifierUserId",
                principalTable: "tsyusers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUserClaims_tsyusers_UserId",
                table: "AbpUserClaims",
                column: "UserId",
                principalTable: "tsyusers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUserLogins_tsyusers_UserId",
                table: "AbpUserLogins",
                column: "UserId",
                principalTable: "tsyusers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUserRoles_tsyusers_UserId",
                table: "AbpUserRoles",
                column: "UserId",
                principalTable: "tsyusers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUserTokens_tsyusers_UserId",
                table: "AbpUserTokens",
                column: "UserId",
                principalTable: "tsyusers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tsyroles_tsyusers_CreatorUserId",
                table: "tsyroles",
                column: "CreatorUserId",
                principalTable: "tsyusers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tsyroles_tsyusers_DeleterUserId",
                table: "tsyroles",
                column: "DeleterUserId",
                principalTable: "tsyusers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tsyroles_tsyusers_LastModifierUserId",
                table: "tsyroles",
                column: "LastModifierUserId",
                principalTable: "tsyusers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tsyusers_tsyusers_CreatorUserId",
                table: "tsyusers",
                column: "CreatorUserId",
                principalTable: "tsyusers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tsyusers_tsyusers_DeleterUserId",
                table: "tsyusers",
                column: "DeleterUserId",
                principalTable: "tsyusers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tsyusers_tsyusers_LastModifierUserId",
                table: "tsyusers",
                column: "LastModifierUserId",
                principalTable: "tsyusers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpPermissions_tsyroles_RoleId",
                table: "AbpPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpPermissions_tsyusers_UserId",
                table: "AbpPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpRoleClaims_tsyroles_RoleId",
                table: "AbpRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpSettings_tsyusers_UserId",
                table: "AbpSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpTenants_tsyusers_CreatorUserId",
                table: "AbpTenants");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpTenants_tsyusers_DeleterUserId",
                table: "AbpTenants");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpTenants_tsyusers_LastModifierUserId",
                table: "AbpTenants");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUserClaims_tsyusers_UserId",
                table: "AbpUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUserLogins_tsyusers_UserId",
                table: "AbpUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUserRoles_tsyusers_UserId",
                table: "AbpUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUserTokens_tsyusers_UserId",
                table: "AbpUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_tsyroles_tsyusers_CreatorUserId",
                table: "tsyroles");

            migrationBuilder.DropForeignKey(
                name: "FK_tsyroles_tsyusers_DeleterUserId",
                table: "tsyroles");

            migrationBuilder.DropForeignKey(
                name: "FK_tsyroles_tsyusers_LastModifierUserId",
                table: "tsyroles");

            migrationBuilder.DropForeignKey(
                name: "FK_tsyusers_tsyusers_CreatorUserId",
                table: "tsyusers");

            migrationBuilder.DropForeignKey(
                name: "FK_tsyusers_tsyusers_DeleterUserId",
                table: "tsyusers");

            migrationBuilder.DropForeignKey(
                name: "FK_tsyusers_tsyusers_LastModifierUserId",
                table: "tsyusers");

            migrationBuilder.DropTable(
                name: "tbltodolists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tsyusers",
                table: "tsyusers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tsyroles",
                table: "tsyroles");

            migrationBuilder.RenameTable(
                name: "tsyusers",
                newName: "AbpUsers");

            migrationBuilder.RenameTable(
                name: "tsyroles",
                newName: "AbpRoles");

            migrationBuilder.RenameIndex(
                name: "IX_tsyusers_TenantId_NormalizedUserName",
                table: "AbpUsers",
                newName: "IX_AbpUsers_TenantId_NormalizedUserName");

            migrationBuilder.RenameIndex(
                name: "IX_tsyusers_TenantId_NormalizedEmailAddress",
                table: "AbpUsers",
                newName: "IX_AbpUsers_TenantId_NormalizedEmailAddress");

            migrationBuilder.RenameIndex(
                name: "IX_tsyusers_LastModifierUserId",
                table: "AbpUsers",
                newName: "IX_AbpUsers_LastModifierUserId");

            migrationBuilder.RenameIndex(
                name: "IX_tsyusers_DeleterUserId",
                table: "AbpUsers",
                newName: "IX_AbpUsers_DeleterUserId");

            migrationBuilder.RenameIndex(
                name: "IX_tsyusers_CreatorUserId",
                table: "AbpUsers",
                newName: "IX_AbpUsers_CreatorUserId");

            migrationBuilder.RenameIndex(
                name: "IX_tsyroles_TenantId_NormalizedName",
                table: "AbpRoles",
                newName: "IX_AbpRoles_TenantId_NormalizedName");

            migrationBuilder.RenameIndex(
                name: "IX_tsyroles_LastModifierUserId",
                table: "AbpRoles",
                newName: "IX_AbpRoles_LastModifierUserId");

            migrationBuilder.RenameIndex(
                name: "IX_tsyroles_DeleterUserId",
                table: "AbpRoles",
                newName: "IX_AbpRoles_DeleterUserId");

            migrationBuilder.RenameIndex(
                name: "IX_tsyroles_CreatorUserId",
                table: "AbpRoles",
                newName: "IX_AbpRoles_CreatorUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbpUsers",
                table: "AbpUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbpRoles",
                table: "AbpRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpPermissions_AbpRoles_RoleId",
                table: "AbpPermissions",
                column: "RoleId",
                principalTable: "AbpRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpPermissions_AbpUsers_UserId",
                table: "AbpPermissions",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpRoleClaims_AbpRoles_RoleId",
                table: "AbpRoleClaims",
                column: "RoleId",
                principalTable: "AbpRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpRoles_AbpUsers_CreatorUserId",
                table: "AbpRoles",
                column: "CreatorUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpRoles_AbpUsers_DeleterUserId",
                table: "AbpRoles",
                column: "DeleterUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpRoles_AbpUsers_LastModifierUserId",
                table: "AbpRoles",
                column: "LastModifierUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpSettings_AbpUsers_UserId",
                table: "AbpSettings",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpTenants_AbpUsers_CreatorUserId",
                table: "AbpTenants",
                column: "CreatorUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpTenants_AbpUsers_DeleterUserId",
                table: "AbpTenants",
                column: "DeleterUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpTenants_AbpUsers_LastModifierUserId",
                table: "AbpTenants",
                column: "LastModifierUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUserClaims_AbpUsers_UserId",
                table: "AbpUserClaims",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUserLogins_AbpUsers_UserId",
                table: "AbpUserLogins",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUserRoles_AbpUsers_UserId",
                table: "AbpUserRoles",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_AbpUsers_CreatorUserId",
                table: "AbpUsers",
                column: "CreatorUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_AbpUsers_DeleterUserId",
                table: "AbpUsers",
                column: "DeleterUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_AbpUsers_LastModifierUserId",
                table: "AbpUsers",
                column: "LastModifierUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUserTokens_AbpUsers_UserId",
                table: "AbpUserTokens",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
