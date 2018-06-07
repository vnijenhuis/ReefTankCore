using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ReefTankCore.Web.Migrations
{
    public partial class MediaUpdate20180129 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Creature_MediaId",
                table: "Creature");

            migrationBuilder.DropColumn(
                name: "CreatureId",
                table: "Media");

            migrationBuilder.AddColumn<Guid>(
                name: "MediaId",
                table: "Subcategory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Category",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MediaId",
                table: "Category",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subcategory_MediaId",
                table: "Subcategory",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Creature_MediaId",
                table: "Creature",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_MediaId",
                table: "Category",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Media_MediaId",
                table: "Category",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategory_Media_MediaId",
                table: "Subcategory",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Media_MediaId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Subcategory_Media_MediaId",
                table: "Subcategory");

            migrationBuilder.DropIndex(
                name: "IX_Subcategory_MediaId",
                table: "Subcategory");

            migrationBuilder.DropIndex(
                name: "IX_Creature_MediaId",
                table: "Creature");

            migrationBuilder.DropIndex(
                name: "IX_Category_MediaId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "Subcategory");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "Category");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatureId",
                table: "Media",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Creature_MediaId",
                table: "Creature",
                column: "MediaId",
                unique: true,
                filter: "[MediaId] IS NOT NULL");
        }
    }
}
