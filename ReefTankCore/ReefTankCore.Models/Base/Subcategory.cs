using System;
using System.Collections.Generic;
using ReefTankCore.Core.Repositories;

namespace ReefTankCore.Models.Base
{
    /// <summary>
    /// The subcategory class is used to categorize marine life by scientific name.
    /// </summary>
    public class Subcategory : IAggregateRoot
    {
        public virtual Guid Id { get; set; }

        public string Slug { get; set; }

        public string CommonName { get; set; }

        public string ScientificName { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Creature> Creatures { get; set; }       

        public Guid? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public Guid? MediaId { get; set; }
        public virtual Media Media { get; set; }
    }
}
