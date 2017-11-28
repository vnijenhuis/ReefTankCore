using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReefTankCore.Models.Inhabitants
{
    public class Tag
    {
        public virtual Guid Id { get; set; }

        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        public virtual TagType TagType { get; set; }

        public virtual ICollection<Inhabitant> Inhabitants { get; set; }
    }
}
