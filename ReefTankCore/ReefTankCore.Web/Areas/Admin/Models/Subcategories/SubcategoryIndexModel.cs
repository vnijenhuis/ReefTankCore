﻿using System;
using System.Collections.Generic;
using ReefTankCore.Models.Base;

namespace ReefTankCore.Web.Areas.Admin.Models.Subcategories
{

    public class SubcategoryIndexModel
    {
        public Guid Id { get; set; }

        public string Slug { get; set; }

        public string CommonName { get; set; }

        public string ScientificName { get; set; }

        public int CreatureCount { get; set; }

        public IList<Creature> Creatures { get; set; }
    }
}
