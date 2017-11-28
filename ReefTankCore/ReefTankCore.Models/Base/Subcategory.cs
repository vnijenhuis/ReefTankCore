using System;
using System.Collections.Generic;

namespace ReefTankCore.Models.Base
{
    /// <summary>
    /// The subcategory class is used to categorize marine life by scientific name.
    /// </summary>
    public class Subcategory
    {
        public Guid Id { get; set; }

        public Category Category { get; set; }

        public string Slug { get; set; }

        public string CommonName { get; set; }

        public string ScientificName { get; set; }

        public ICollection<Genus> Genera { get; set; }
        
        public virtual string Description { get; set; }
    }
}
