using System;
using System.Collections.Generic;
using ReefTankCore.Models.Base;

namespace ReefTank.Models.Base
{
    public class Reference
    {
        public Guid Id { get; set; }

        public string Website { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public string Source { get; set; }

        public DateTime DateLastUpdated { get; set; }

        public virtual  ICollection<CreatureReference> CreatureReferences { get; set; }
    }
}
