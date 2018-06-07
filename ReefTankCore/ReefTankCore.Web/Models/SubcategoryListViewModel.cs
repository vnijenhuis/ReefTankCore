using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReefTankCore.Web.Areas.Admin.Models;

namespace ReefTankCore.Web.Models
{
    public class SubcategoryListViewModel
    {
        public Guid Id { get; set; }

        public string CommonName { get; set; }

        public string ScientificName { get; set; }

        public MediaViewModel Media { get; set; }
    }
}
