using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ReefTankCore.Web.Migrations
{
    public partial class AuthenticationV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaim_Role_RoleId1",
                table: "RoleClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaim_User_UserId1",
                table: "UserClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogin_User_UserId1",
                table: "UserLogin");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Role_RoleId1",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_User_UserId1",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_UserRole_RoleId1",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_UserLogin_UserId1",
                table: "UserLogin");

            migrationBuilder.DropIndex(
                name: "IX_UserClaim_UserId1",
                table: "UserClaim");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserLogin");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserClaim");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "UserRole",
                newName: "RoleId2");

            migrationBuilder.RenameIndex(
                name: "IX_UserRole_UserId1",
                table: "UserRole",
                newName: "IX_UserRole_RoleId2");

            migrationBuilder.RenameColumn(
                name: "RoleId1",
                table: "RoleClaim",
                newName: "RoleId2");

            migrationBuilder.RenameIndex(
                name: "IX_RoleClaim_RoleId1",
                table: "RoleClaim",
                newName: "IX_RoleClaim_RoleId2");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaim_Role_RoleId2",
                table: "RoleClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Role_RoleId2",
                table: "UserRole");

            migrationBuilder.RenameColumn(
                name: "RoleId2",
                table: "UserRole",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_UserRole_RoleId2",
                table: "UserRole",
                newName: "IX_UserRole_UserId1");

            migrationBuilder.RenameColumn(
                name: "RoleId2",
                table: "RoleClaim",
                newName: "RoleId1");

            migrationBuilder.RenameIndex(
                name: "IX_RoleClaim_RoleId2",
                table: "RoleClaim",
                newName: "IX_RoleClaim_RoleId1");

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId1",
                table: "UserRole",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "UserLogin",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "UserClaim",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId1",
                table: "UserRole",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId1",
                table: "UserLogin",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId1",
                table: "UserClaim",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaim_Role_RoleId1",
                table: "RoleClaim",
                column: "RoleId1",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaim_User_UserId1",
                table: "UserClaim",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogin_User_UserId1",
                table: "UserLogin",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Role_RoleId1",
                table: "UserRole",
                column: "RoleId1",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_User_UserId1",
                table: "UserRole",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
