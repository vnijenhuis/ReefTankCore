using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReefTankCore.Web.Areas.Admin.Models
{
    public class CategoryIndexModel
    {
        public Guid Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }

        public int SubcategoryCount { get; set; }
    }
}
