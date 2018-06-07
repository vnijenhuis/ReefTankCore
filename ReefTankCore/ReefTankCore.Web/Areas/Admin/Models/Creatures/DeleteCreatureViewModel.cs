using System;

namespace ReefTankCore.Web.Areas.Admin.Models.Creatures
{
    public class DeleteCreatureViewModel
    {
        public Guid Id { get; set; }
        public string CommonName { get; set; }
        public string Subcategory { get; set; }
        public Guid SubcategoryId { get; set; }
        public string Genus { get; set; }
        public string Species { get; set; }
    }
}