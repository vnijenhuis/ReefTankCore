using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReefTankCore.Models.Inhabitants;

namespace ReefTankCore.Web.Data
{
    public class ReefContext : DbContext
    {
        public ReefContext(DbContextOptions<ReefContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Inhabitant>().ToTable("Inhabitant");
            builder.Entity<Family>().ToTable("Family");
            builder.Entity<Genus>().ToTable("Genus");
            builder.Entity<Tag>().ToTable("Tag");
            builder.Entity<Reference>().ToTable("Reference");
        }

        public DbSet<Inhabitant> Inhabitants { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Genus> Genuses { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Reference> References { get; set; }

    }
}
