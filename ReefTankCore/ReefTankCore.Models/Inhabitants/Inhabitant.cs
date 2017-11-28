using System;
using System.Collections.Generic;

namespace ReefTankCore.Models.Inhabitants
{
    public class Inhabitant
    {
        public virtual Guid Id { get; set; }

        #region Biology

        public virtual string Name { get; set; }
        public virtual Genus Genus { get; set; }

        public virtual string Species { get; set; }

        public virtual string LatinName
        {
            get
            {
                var fullName = Genus.Name;
                fullName += " " + Species;
                return fullName;
            }
        }

        public virtual int Length { get; set; }


        #endregion

        #region Aquarium Info

        public virtual int Volume { get; set; }

        public virtual string AquariumSuitability { get; set; }

        public virtual ReefSafety ReefSafety { get; set; }

        public virtual Temperament Temperament { get; set; }

        public virtual Hardiness Hardiness { get; set; }

        public virtual Suitability Suitability { get; set; }

        #endregion

        #region About
        public virtual string Description { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Reference> References { get; set; }

        #endregion
    }
}
