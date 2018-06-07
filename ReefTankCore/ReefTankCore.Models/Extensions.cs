using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ReefTank.Models.Base;
using ReefTankCore.Core.Repositories;
using ReefTankCore.Models.Base;
using ReefTankCore.Models.Users;

namespace ReefTankCore.Models
{
    public static class Extensions
    {
        public static IQueryable<Creature> BuildCreature(this IQueryable<Creature> query)
        {
            return query
                .Include(x => x.CreatureReferences)
                    .ThenInclude(x => x.Reference)
                .Include(x => x.CreatureTags)
                    .ThenInclude(x => x.Tag)
                .Include(x => x.Media)
                .Include(x => x.Subcategory)
                    .ThenInclude(x => x.Category);
        }

        public static IQueryable<Category> BuildCategory(this IQueryable<Category> query)
        {
            return query
                .Include(x => x.Subcategories)
                    .ThenInclude(x => x.Media)
                .Include(x => x.Media);
        }

        public static IQueryable<Subcategory> BuildSubcategory(this IQueryable<Subcategory> query)
        {
            return query
                .Include(x => x.Creatures)
                    .ThenInclude(x => x.Media)
                .Include(x => x.Media);
        }

        public static IQueryable<CreatureTag> BuildCreatureTag(this IQueryable<CreatureTag> query)
        {
            return query
                .Include(x => x.Creature)
                .Include(x => x.Tag);
        }

        public static IQueryable<Tag> BuildTag(this IQueryable<Tag> query)
        {
            return query.Include(x => x.CreatureTags);
        }

        public static IQueryable<CreatureReference> BuildCreatureReference(this IQueryable<CreatureReference> query)
        {
            return query
                .Include(x => x.Creature)
                .Include(x => x.Reference);
        }

        public static IQueryable<Reference> BuildReference(this IQueryable<Reference> query)
        {
            return query.Include(x => x.CreatureReferences);
        }

        //public static IQueryable<T> Inclusion<T>(this IQueryable<T> query) where T: class, IAggregateRoot
        //{
        //    var type = typeof(T);
        //    foreach (var property in type.GetProperties())
        //    {
        //        if (property.PropertyType.BaseType == typeof(ICollection) || property.PropertyType == typeof(IAggregateRoot))
        //        {
        //            query.Include(x => property);
        //            if (property.PropertyType.GetProperties().Any())
        //            {
        //                if (property.PropertyType == typeof(ICollection<>) ||
        //                    property.PropertyType == typeof(IAggregateRoot))
        //                {
        //                    query.Include(x => property);
        //                }
        //            }
        //        }
        //    }
        //    return query;
        //}
    }
}
