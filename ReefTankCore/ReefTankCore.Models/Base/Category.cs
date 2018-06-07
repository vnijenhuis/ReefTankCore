using System;
using System.Collections.Generic;
using ReefTank.Models.Base;
using ReefTankCore.Core.Repositories;

namespace ReefTankCore.Models.Base
{
    public class Category : IAggregateRoot
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Subcategory> Subcategories { get; set; }

        public Guid? MediaId { get; set; }
        public virtual Media Media { get; set; }
    }
}
