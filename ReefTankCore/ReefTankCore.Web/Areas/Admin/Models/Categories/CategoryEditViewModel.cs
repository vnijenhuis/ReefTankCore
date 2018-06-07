using System;
using System.Collections.Generic;
using ReefTankCore.Web.Areas.Admin.Models.Subcategories;

namespace ReefTankCore.Web.Areas.Admin.Models.Categories
{
    public class CategoryEditViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string ContentUrl { get; set; }
        public string FileName { get; set; }
        public IList<SubcategoryIndexModel> Subcategories { get; set; }
    }
}