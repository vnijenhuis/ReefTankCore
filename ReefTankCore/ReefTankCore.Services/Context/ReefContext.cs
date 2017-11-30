using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ReefTank.Models.Base;
using ReefTankCore.Models.Base;
using ReefTankCore.Models.Corals;
using ReefTankCore.Models.Inhabitants;

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
            modelBuilder.Entity<Inhabitant>().ToTable("Inhabitant");
            modelBuilder.Entity<Coral>().ToTable("Coral");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Subcategory>().ToTable("Subcategory");
            modelBuilder.Entity<Tag>().ToTable("Tag");
            modelBuilder.Entity<Reference>().ToTable("Reference");
        }

        public DbSet<Inhabitant> Inhabitants { get; set; }
        public DbSet<Coral> Corals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Reference> References { get; set; }

        public IEnumerable<Inhabitant> GetInhabitants()
        {
            return Inhabitants;
        }

    }
}
