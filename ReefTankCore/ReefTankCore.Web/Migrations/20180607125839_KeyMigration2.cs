using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ReefTankCore.Web.Migrations
{
    public partial class KeyMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_CreatureTag_Id",
                table: "CreatureTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreatureTag",
                table: "CreatureTag");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_CreatureReference_Id",
                table: "CreatureReference");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreatureReference",
                table: "CreatureReference");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreatureTag",
                table: "CreatureTag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreatureReference",
                table: "CreatureReference",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureTag_CreatureId",
                table: "CreatureTag",
                column: "CreatureId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureReference_CreatureId",
                table: "CreatureReference",
                column: "CreatureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CreatureTag",
                table: "CreatureTag");

            migrationBuilder.DropIndex(
                name: "IX_CreatureTag_CreatureId",
                table: "CreatureTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreatureReference",
                table: "CreatureReference");

            migrationBuilder.DropIndex(
                name: "IX_CreatureReference_CreatureId",
                table: "CreatureReference");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CreatureTag_Id",
                table: "CreatureTag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreatureTag",
                table: "CreatureTag",
                columns: new[] { "CreatureId", "TagId" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CreatureReference_Id",
                table: "CreatureReference",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreatureReference",
                table: "CreatureReference",
                columns: new[] { "CreatureId", "ReferenceId" });
        }
    }
}
