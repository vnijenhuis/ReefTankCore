using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReefTankCore.Models.Base;

namespace ReefTankCore.Web.Areas.Admin.Models
{

    public class CreatureIndexModel
    {
        public Guid Id { get; set; }

        public string CommonName { get; set; }

        public string Description { get; set; }

        public string Genus { get; set; }

        public string Species { get; set; }

        public string Origin { get; set; }
    }
}
