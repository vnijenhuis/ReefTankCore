﻿using System;
using System.Collections.Generic;
using ReefTank.Models.Base;

namespace ReefTankCore.Models.Base
{
    public class Genus
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Subcategory Subcategory { get; set; }

        public ICollection<Creature> Creatures { get; set; }
    }
}
