using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReefTankCore.Models.Base;
using ReefTankCore.Services.Context;
using ReefTankCore.Web.Areas.Admin.Models.Categories;
using ReefTankCore.Web.Areas.Admin.Models.Subcategories;

namespace ReefTankCore.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubcategoryController : Controller
    {
        private readonly IReefService _reefService;

        public SubcategoryController(IReefService reefService)
        {
            _reefService = reefService;
        }

        [HttpGet]
        public IActionResult Index(string slug)
        {
            var category = _reefService.GetCategory(slug) ?? _reefService.GetFirstCategory();
            var subcategories = _reefService.GetSubcategories(category).ToList();
            var vm = new CategoryDetailsModel()
            {
                Id = category.Id,
                Name = category.Name,
                Slug = category.Slug,
                Subcategories = Mapper.Map<IEnumerable<Subcategory>, IList<SubcategoryIndexModel>>(subcategories),
            };
            return View(vm);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit(Guid id)
        {
            return View();
        }
     }
}