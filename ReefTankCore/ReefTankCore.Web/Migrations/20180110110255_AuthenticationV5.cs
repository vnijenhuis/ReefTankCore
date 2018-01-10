using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ReefTankCore.Web.Migrations
{
    public partial class AuthenticationV5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaim_Role_RoleId2",
                table: "RoleClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Role_RoleId2",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToken_User_UserId1",
                table: "UserToken");

            migrationBuilder.DropIndex(
                name: "IX_UserToken_UserId1",
                table: "UserToken");

            migrationBuilder.DropIndex(
                name: "IX_UserRole_RoleId2",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_RoleClaim_RoleId2",
                table: "RoleClaim");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserToken");

            migrationBuilder.DropColumn(
                name: "RoleId2",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "RoleId2",
                table: "RoleClaim");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "UserToken",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId2",
                table: "UserRole",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId2",
                table: "RoleClaim",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_UserId1",
                table: "UserToken",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId2",
                table: "UserRole",
                column: "RoleId2");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId2",
                table: "RoleClaim",
                column: "RoleId2");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaim_Role_RoleId2",
                table: "RoleClaim",
                column: "RoleId2",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Role_RoleId2",
                table: "UserRole",
                column: "RoleId2",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserToken_User_UserId1",
                table: "UserToken",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
