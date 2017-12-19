using System;
using System.Collections.Generic;

namespace ReefTankCore.Web.Areas.Admin.Models
{
    public class SubcategoryDetailsModel
    {
        public Guid Id { get; set; }
        public string Slug { get; set; }
        public string CommonName { get; set; }
        public string ScientificName { get; set; }
        public string Description { get; set; }
        public IList<CreatureIndexModel> Creatures { get; set; }
        public string CategorySlug { get; set; }
        public string CategoryName { get; set; }
    }
}