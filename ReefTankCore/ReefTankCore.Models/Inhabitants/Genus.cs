using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ReefTankCore.Models.Inhabitants
{
    public class Genus
    {
        public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }

        public virtual Family Family { get; set; }

        public virtual ICollection<Inhabitant> ReefInhabitants { get; set; }
    }
}
