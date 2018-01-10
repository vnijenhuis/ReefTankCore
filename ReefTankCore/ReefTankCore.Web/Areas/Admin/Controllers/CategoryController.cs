using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReefTankCore.Models.Base;
using ReefTankCore.Services.Context;
using ReefTankCore.Web.Areas.Admin.Models.Categories;

namespace ReefTankCore.Web.Areas.Admin.Controllers
{
    public class CategoryController : AdminController
    {
        private readonly IReefService _reefService;

        public CategoryController(IReefService reefService)
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