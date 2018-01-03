using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ReefTankCore.Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ContentType = table.Column<string>(nullable: true),
                    CreatureId = table.Column<Guid>(nullable: false),
                    Filename = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reference",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateLastUpdated = table.Column<DateTime>(nullable: false),
                    Slug = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reference", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    TagType = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subcategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false),
                    CommonName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ScientificName = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subcategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Creature",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CommonName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Diet = table.Column<string>(nullable: true),
                    Difficulty = table.Column<int>(nullable: false),
                    DifficultyDescription = table.Column<string>(nullable: true),
                    Fragmenting = table.Column<string>(nullable: true),
                    Genus = table.Column<string>(nullable: true),
                    Length = table.Column<double>(nullable: false),
                    Lighting = table.Column<string>(nullable: true),
                    MaximumCalciumPpm = table.Column<int>(nullable: false),
                    MaximumPh = table.Column<double>(nullable: false),
                    MaximumTemperature = table.Column<double>(nullable: false),
                    MediaId = table.Column<Guid>(nullable: false),
                    MinimumCalciumPpm = table.Column<int>(nullable: false),
                    MinimumPh = table.Column<double>(nullable: false),
                    MinimumTemperature = table.Column<double>(nullable: false),
                    Origin = table.Column<string>(nullable: true),
                    ReefCompatability = table.Column<int>(nullable: false),
                    SpecialRequirements = table.Column<int>(nullable: false),
                    Species = table.Column<string>(nullable: true),
                    SubcategoryId = table.Column<Guid>(nullable: false),
                    Temperament = table.Column<int>(nullable: false),
                    Volume = table.Column<double>(nullable: false),
                    WaterMovement = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Creature_Media_Id",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Creature_Subcategory_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "Subcategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreatureReference",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatureId = table.Column<Guid>(nullable: false),
                    ReferenceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureReference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreatureReference_Creature_CreatureId",
                        column: x => x.CreatureId,
                        principalTable: "Creature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreatureReference_Reference_ReferenceId",
                        column: x => x.ReferenceId,
                        principalTable: "Reference",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreatureTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatureId = table.Column<Guid>(nullable: false),
                    TagId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreatureTags_Creature_CreatureId",
                        column: x => x.CreatureId,
                        principalTable: "Creature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreatureTags_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Creature_SubcategoryId",
                table: "Creature",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureReference_CreatureId",
                table: "CreatureReference",
                column: "CreatureId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureReference_ReferenceId",
                table: "CreatureReference",
                column: "ReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureTags_CreatureId",
                table: "CreatureTags",
                column: "CreatureId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureTags_TagId",
                table: "CreatureTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategory_CategoryId",
                table: "Subcategory",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreatureReference");

            migrationBuilder.DropTable(
                name: "CreatureTags");

            migrationBuilder.DropTable(
                name: "Reference");

            migrationBuilder.DropTable(
                name: "Creature");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "Subcategory");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}

