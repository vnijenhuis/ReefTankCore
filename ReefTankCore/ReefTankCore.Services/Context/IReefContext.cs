using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReefTank.Models.Base;
using ReefTankCore.Models.Base;
using ReefTankCore.Models.Users;

namespace ReefTankCore.Services.Context
{
    public interface IReefContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Subcategory> Subcategories { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<Reference> References { get; set; }
        DbSet<CreatureReference> CreatureReferences { get; set; }
        DbSet<CreatureTag> CreatureTags { get; set; }
        DbSet<Media> Media { get; set; }
        DbSet<Creature> Creatures { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        void Dispose();
    }
}
