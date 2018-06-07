using System;
using System.Collections.Generic;
using ReefTankCore.Web.Areas.Admin.Models;

namespace ReefTankCore.Web.Models
{

    public class SubcategoryViewModel
    {
        public Guid Id { get; set; }

        public string CommonName { get; set; }

        public string ScientificName { get; set; }

        public virtual string Description { get; set; }

        public MediaViewModel Media { get; set; }

        public IList<CreatureViewModel> Creatures { get; set; }
    }
}
