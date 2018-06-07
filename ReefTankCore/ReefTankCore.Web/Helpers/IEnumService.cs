using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ReefTankCore.Web.Helpers
{
    public interface IEnumService
    {
        List<SelectListItem> GetReefCompatability();
        List<SelectListItem> GetTemperament();
        List<SelectListItem> GetDifficulties();
        List<SelectListItem> GetSpecialRequirements();
    }
}
