using System;

namespace ReefTankCore.Web.Models
{

    public class SubcategoryViewModel
    {
        public Guid Id { get; set; }

        public string Slug { get; set; }

        public string CommonName { get; set; }

        public string ScientificName { get; set; }

        public virtual string Description { get; set; }
    }
}
