using System;
using System.Collections.Generic;
using ReefTankCore.Web.Areas.Admin.Models.Subcategories;

namespace ReefTankCore.Web.Areas.Admin.Models.Categories
{
    public class CategoryDetailsModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public IList<SubcategoryIndexModel> Subcategories { get; set; }
    }
}