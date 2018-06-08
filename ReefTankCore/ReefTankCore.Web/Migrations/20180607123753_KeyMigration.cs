using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ReefTankCore.Web.Migrations
{
    public partial class KeyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_CreatureTag_Id",
                table: "CreatureTag",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CreatureReference_Id",
                table: "CreatureReference",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_CreatureTag_Id",
                table: "CreatureTag");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_CreatureReference_Id",
                table: "CreatureReference");
        }
    }
}
