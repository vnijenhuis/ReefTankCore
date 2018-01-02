using System;

namespace ReefTankCore.Web.Areas.Admin.Models.Creatures
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
