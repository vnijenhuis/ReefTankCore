﻿using System;
using System.Collections.Generic;
using ReefTankCore.Core.Repositories;
using ReefTankCore.Models.Enums;

namespace ReefTankCore.Models.Base
{
    public class Tag : IAggregateRoot
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        public TagType TagType { get; set; }

        public virtual ICollection<CreatureTag> CreatureTags { get; set; }
    }
}
