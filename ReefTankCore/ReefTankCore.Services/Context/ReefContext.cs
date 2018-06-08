using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReefTank.Models.Base;
using ReefTankCore.Models.Base;
using ReefTankCore.Models.Users;

namespace ReefTankCore.Services.Context
{
    public class ReefContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public DbContextOptions<ReefContext> Options { get; }

        public ReefContext(DbContextOptions<ReefContext> options) : base(options)
        {
            Options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Creature>(b =>
            {
                b.ToTable("Creature");
                b.HasOne(x => x.Subcategory)
                    .WithMany(x => x.Creatures)
                    .HasForeignKey(x => x.SubcategoryId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasMany(x => x.CreatureReferences)
                    .WithOne(x => x.Creature)
                    .HasForeignKey(x => x.CreatureId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasMany(x => x.CreatureTags)
                    .WithOne(x => x.Creature)
                    .HasForeignKey(x => x.CreatureId)
                    .OnDelete(DeleteBehavior.Cascade);
                b.HasOne(x => x.Media);
            });

            //modelBuilder.Entity<Media>().ToTable("Media")
            //    .HasOne(x => x.Creature)
            //    .WithOne(x => x.Media)
            //    .HasForeignKey<Creature>(x => new { x.MediaId });

            modelBuilder.Entity<Category>().ToTable("Category")
                .HasMany(c => c.Subcategories)
                .WithOne(s => s.Category)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Subcategory>().ToTable("Subcategory")
                .HasOne(x => x.Category)
                .WithMany(x => x.Subcategories)
                .HasForeignKey(x => new { x.CategoryId })
                .OnDelete(DeleteBehavior.Cascade)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tag>().ToTable("Tag")
                .HasMany(x => x.CreatureTags)
                .WithOne(x => x.Tag)
                .HasForeignKey(x => new { x.TagId })
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reference>().ToTable("Reference")
                .HasMany(x => x.CreatureReferences)
                .WithOne(x => x.Reference)
                .HasForeignKey(x => new { x.ReferenceId })
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CreatureTag>().ToTable("CreatureTag")
                .HasKey(t => new { t.Id });

            modelBuilder.Entity<CreatureReference>().ToTable("CreatureReference")
                .HasKey(x => new { x.Id });

            modelBuilder.Entity<User>(b =>
                {
                    b.ToTable("User");
                });

            modelBuilder.Entity<Role>(b =>
                {
                    b.ToTable("Role");
                });

            modelBuilder.Entity<UserRole>(b =>
            {
                b.ToTable("UserRole");
                b.HasOne("ReefTankCore.Models.Users.Role")
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("ReefTankCore.Models.Users.User")
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<UserClaim>(b =>
            {
                b.ToTable("UserClaim");
                b.HasOne("ReefTankCore.Models.Users.User")
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<RoleClaim>(b =>
            {
                b.ToTable("RoleClaim");
                b.HasOne("ReefTankCore.Models.Users.Role")
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<UserLogin>(b =>
                {
                    b.ToTable("UserLogin");
                    b.HasOne("ReefTankCore.Models.Users.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity<UserToken>(b =>
               {
                   b.ToTable("UserToken");
                   b.HasOne("ReefTankCore.Models.Users.User")
                        .WithMany()
                       .HasForeignKey("UserId");
               });
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
