using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ReefTank.Models.Base;
using ReefTankCore.Models.Base;
using ReefTankCore.Models.Users;

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
            modelBuilder.Entity<Creature>()
                .HasOne(x => x.Subcategory)
                .WithMany(x => x.Creatures)
                .HasForeignKey(x => x.SubcategoryId);

            modelBuilder.Entity<Creature>()
                .HasMany(x => x.CreatureReferences)
                .WithOne(x => x.Creature)
                .HasForeignKey(x => x.CreatureId);

            modelBuilder.Entity<Creature>()
                .HasMany(x => x.CreatureTags)
                .WithOne(x => x.Creature)
                .HasForeignKey(x => x.CreatureId);

            modelBuilder.Entity<Media>().ToTable("Media")
                .HasOne(x => x.Creature)
                .WithOne(x => x.Media)
                .HasForeignKey<Creature>(x => new { x.MediaId });

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

            modelBuilder.Entity<Reference>().ToTable("Reference")
                .HasMany(x => x.CreatureReferences)
                .WithOne(x => x.Reference)
                .HasForeignKey(x => new { x.ReferenceId });

            modelBuilder.Entity<CreatureTag>().ToTable("CreatureTag")
                .HasKey(t => new { t.CreatureId, t.TagId });

            modelBuilder.Entity<CreatureReference>().ToTable("CreatureReference")
                .HasKey(x => new { x.CreatureId, x.ReferenceId });

            modelBuilder.Entity<User>().ToTable("User");
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
