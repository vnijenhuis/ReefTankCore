using System;
using System.Collections.Generic;
using ReefTank.Models.Base;

namespace ReefTankCore.Models.Base
{
    public class Tag
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        public TagType TagType { get; set; }

        public ICollection<CreatureTag> CreatureTags { get; set; }
    }
}
