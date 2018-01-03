﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ReefTankCore.Models.Enums;
using ReefTankCore.Services.Context;
using System;

namespace ReefTankCore.Web.Migrations
{
    [DbContext(typeof(ReefContext))]
    [Migration("20171220122302_NewMedia")]
    partial class NewMedia
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReefTank.Models.Base.Reference", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateLastUpdated");

                    b.Property<string>("Slug");

                    b.Property<string>("Source");

                    b.Property<string>("Title");

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.ToTable("Reference");
                });

            modelBuilder.Entity("ReefTankCore.Models.Base.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Slug");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ReefTankCore.Models.Base.Creature", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("CommonName");

                    b.Property<string>("Description");

                    b.Property<string>("Diet");

                    b.Property<int>("Difficulty");

                    b.Property<string>("DifficultyDescription");

                    b.Property<string>("Fragmenting");

                    b.Property<string>("Genus");

                    b.Property<double>("Length");

                    b.Property<string>("Lighting");

                    b.Property<int>("MaximumCalciumPpm");

                    b.Property<double>("MaximumPh");

                    b.Property<double>("MaximumTemperature");

                    b.Property<Guid>("MediaId");

                    b.Property<int>("MinimumCalciumPpm");

                    b.Property<double>("MinimumPh");

                    b.Property<double>("MinimumTemperature");

                    b.Property<string>("Origin");

                    b.Property<int>("ReefCompatability");

                    b.Property<int>("SpecialRequirements");

                    b.Property<string>("Species");

                    b.Property<Guid>("SubcategoryId");

                    b.Property<int>("Temperament");

                    b.Property<double>("Volume");

                    b.Property<string>("WaterMovement");

                    b.HasKey("Id");

                    b.HasIndex("SubcategoryId");

                    b.ToTable("Creature");
                });

            modelBuilder.Entity("ReefTankCore.Models.Base.CreatureReference", b =>
                {
                    b.Property<Guid>("CreatureId");

                    b.Property<Guid>("ReferenceId");

                    b.Property<Guid>("Id");

                    b.HasKey("CreatureId", "ReferenceId");

                    b.HasIndex("ReferenceId");

                    b.ToTable("CreatureReference");
                });

            modelBuilder.Entity("ReefTankCore.Models.Base.CreatureTag", b =>
                {
                    b.Property<Guid>("CreatureId");

                    b.Property<Guid>("TagId");

                    b.Property<Guid>("Id");

                    b.HasKey("CreatureId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("CreatureTag");
                });

            modelBuilder.Entity("ReefTankCore.Models.Base.Media", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContentType");

                    b.Property<Guid>("CreatureId");

                    b.Property<string>("Filename");

                    b.Property<byte[]>("Image");

                    b.HasKey("Id");

                    b.ToTable("Media");
                });

            modelBuilder.Entity("ReefTankCore.Models.Base.Subcategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryId");

                    b.Property<string>("CommonName");

                    b.Property<string>("Description");

                    b.Property<string>("ScientificName");

                    b.Property<string>("Slug");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Subcategory");
                });

            modelBuilder.Entity("ReefTankCore.Models.Base.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Slug");

                    b.Property<int>("TagType");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("ReefTankCore.Models.Base.Creature", b =>
                {
                    b.HasOne("ReefTankCore.Models.Base.Media", "Media")
                        .WithOne("Creature")
                        .HasForeignKey("ReefTankCore.Models.Base.Creature", "Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ReefTankCore.Models.Base.Subcategory", "Subcategory")
                        .WithMany("Creatures")
                        .HasForeignKey("SubcategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReefTankCore.Models.Base.CreatureReference", b =>
                {
                    b.HasOne("ReefTankCore.Models.Base.Creature", "Creature")
                        .WithMany("CreatureReferences")
                        .HasForeignKey("CreatureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ReefTank.Models.Base.Reference", "Reference")
                        .WithMany("CreatureReferences")
                        .HasForeignKey("ReferenceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReefTankCore.Models.Base.CreatureTag", b =>
                {
                    b.HasOne("ReefTankCore.Models.Base.Creature", "Creature")
                        .WithMany("CreatureTags")
                        .HasForeignKey("CreatureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ReefTankCore.Models.Base.Tag", "Tag")
                        .WithMany("CreatureTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReefTankCore.Models.Base.Subcategory", b =>
                {
                    b.HasOne("ReefTankCore.Models.Base.Category", "Category")
                        .WithMany("Subcategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
