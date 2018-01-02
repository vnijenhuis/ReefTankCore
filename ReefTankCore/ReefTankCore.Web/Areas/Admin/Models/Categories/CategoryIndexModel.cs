using System;

namespace ReefTankCore.Web.Areas.Admin.Models.Categories
{
    public class CategoryIndexModel
    {
        public Guid Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }

        public int SubcategoryCount { get; set; }
    }
}
