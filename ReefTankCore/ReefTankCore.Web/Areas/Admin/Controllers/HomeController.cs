using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReefTankCore.Models.Base;
using ReefTankCore.Services.Context;
using ReefTankCore.Web.Areas.Admin.Models;
using ReefTankCore.Web.Areas.Admin.Models.Categories;
using ReefTankCore.Web.Models;

namespace ReefTankCore.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {
        private readonly IReefService _reefService;

        public HomeController(IReefService reefService)
        {
            _reefService = reefService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categories = _reefService.GetCategories();
            var vm = new CategoryOverviewModel()
            {
                Categories = Mapper.Map<IEnumerable<Category>, IList<CategoryIndexModel>>(categories),
            };
            return View(vm);
        }
    }
}