using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReefTankCore.Models.Inhabitants
{
    public class Reference
    {
        public virtual Guid Id { get; set; }

        public virtual string Website { get; set; }

        public virtual string Title { get; set; }

        public virtual string Source { get; set; }

        public virtual DateTime DateLastUpdated { get; set; }

        public virtual ICollection<Inhabitant> Inhabitants { get; set; }
    }
}
