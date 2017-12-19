using System;
using System.Collections.Generic;
using ReefTank.Models.Base;

namespace ReefTankCore.Models.Base
{
    public class Category
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string Slug { get; set; }

        public virtual ICollection<Subcategory> Subcategories { get; set; }
    }
}
