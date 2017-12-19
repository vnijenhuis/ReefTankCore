using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReefTankCore.Web.Areas.Admin.Models;

namespace ReefTankCore.Web.Models
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public IList<SubcategoryViewModel> Subcategories { get; set; }
    }
}
