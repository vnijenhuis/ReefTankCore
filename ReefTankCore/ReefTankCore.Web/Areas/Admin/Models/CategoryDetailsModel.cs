using System;
using System.Collections.Generic;

namespace ReefTankCore.Web.Areas.Admin.Models
{
    public class CategoryDetailsModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public IList<SubcategoryIndexModel> Subcategories { get; set; }
    }
}