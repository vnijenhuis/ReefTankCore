using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ReefTankCore.Web.Migrations
{
    public partial class AuthenticationV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_UserRole_Id",
                table: "UserRole");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_UserLogin_Id",
                table: "UserLogin");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserLogin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserRole",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserLogin",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_UserRole_Id",
                table: "UserRole",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_UserLogin_Id",
                table: "UserLogin",
                column: "Id");
        }
    }
}
