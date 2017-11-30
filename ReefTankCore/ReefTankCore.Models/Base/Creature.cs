using System;
using System.Collections.Generic;
using ReefTank.Models.Base;

namespace ReefTankCore.Models.Base
{
    public class Creature
    {
        public Guid Id { get; set; }

        public string CommonName { get; set; }

        public string Description { get; set; }

        public Subcategory Subcategory { get; set; }

        public string Genus { get; set; }

        public string Species { get; set; }

        public string Origin { get; set; }

        public string ScientificName
        {
            get
            {
                var fullName = Genus;
                fullName += " " + Species;
                return fullName;
            }
        }

        public ICollection<CreatureTag> CreatureTags { get; set; }

        public ICollection<CreatureReference> CreatureReferences { get; set; }

        public virtual string Diet { get; set; }
    }
}
