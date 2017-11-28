using System;
using System.Collections.Generic;

namespace ReefTankCore.Models.Inhabitants
{
    public class Family
    {
        public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }

        public virtual ICollection<Genus> Genus { get; set; }
        
        public virtual string Description { get; set; }
    }
}
