using System;
using System.Collections.Generic;

namespace ReefTankCore.Models.Base
{
    /// <summary>
    /// The subcategory class is used to categorize marine life by scientific name.
    /// </summary>
    public class Subcategory
    {
        public virtual Guid Id { get; set; }

        public string Slug { get; set; }

        public string CommonName { get; set; }

        public string ScientificName { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Creature> Creatures { get; set; }       

        public virtual Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
