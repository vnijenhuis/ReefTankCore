using System.Collections.Generic;

namespace ReefTankCore.Web.Areas.Admin.Models.Categories
{
    public class CategoryOverviewModel
    {
        public IList<CategoryIndexModel> Categories { get; set; }
    }
}