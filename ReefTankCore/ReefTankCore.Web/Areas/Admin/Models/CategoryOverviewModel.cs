using System.Collections.Generic;

namespace ReefTankCore.Web.Areas.Admin.Models
{
    public class CategoryOverviewModel
    {
        public IList<CategoryIndexModel> Categories { get; set; }
    }
}