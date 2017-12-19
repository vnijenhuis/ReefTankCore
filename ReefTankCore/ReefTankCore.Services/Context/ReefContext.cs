using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ReefTank.Models.Base;
using ReefTankCore.Models.Base;

namespace ReefTankCore.Services.Context
{
    public class ReefContext : DbContext
    {
        public DbContextOptions<ReefContext> Options { get; }

        public ReefContext(DbContextOptions<ReefContext> options) : base(options)
        {
            Options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Creature>().ToTable("Creature");

            modelBuilder.Entity<Category>().ToTable("Category")
                .HasMany(c => c.Subcategories)
                .WithOne(s => s.Category);

            modelBuilder.Entity<Subcategory>().ToTable("Subcategory")
                .HasOne(x => x.Category)
                .WithMany(x => x.Subcategories)
                .HasForeignKey(x => new { x.CategoryId })
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tag>().ToTable("Tag")
                .HasMany(x => x.CreatureTags)
                .WithOne(x => x.Tag)
                .HasForeignKey(x => new { x.TagId });

            modelBuilder.Entity<Reference>().ToTable("Reference");

            modelBuilder.Entity<CreatureReference>().ToTable("CreatureReference")
                .HasOne(x => x.Creature)
                .WithMany(x => x.CreatureReferences)
                .HasForeignKey(x => new { x.CreatureId});

            modelBuilder.Entity<CreatureReference>().ToTable("CreatureReference")
                .HasOne(x => x.Reference)
                .WithMany(x => x.CreatureReferences)
                .HasForeignKey(x => new {x.ReferenceId});

            modelBuilder.Entity<Media>().ToTable("Media")
                .HasOne(x => x.Creature)
                .WithOne(x => x.Logo)
                .HasForeignKey<Creature>(x => new {x.Id});
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<CreatureReference> CreatureReferences { get; set; }
        public DbSet<CreatureTag> CreatureTags { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Creature> Creatures { get; set; }
    }
}
