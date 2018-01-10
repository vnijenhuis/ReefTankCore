using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReefTankCore.Models.Base;
using ReefTankCore.Services.Context;
using ReefTankCore.Web.Areas.Admin.Models.Categories;
using ReefTankCore.Web.Areas.Admin.Models.Subcategories;
using ReefTankCore.Web.Models;

namespace ReefTankCore.Web.Areas.Admin.Controllers
{
    public class SubcategoryController : AdminController
    {
        private readonly IReefService _reefService;

        public SubcategoryController(IReefService reefService)
        {
            _reefService = reefService;
        }

        [HttpGet]
        public IActionResult Index(Guid id)
        {
            var category = _reefService.GetCategory(id) ?? _reefService.GetFirstCategory();
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

        [HttpGet]
        public IActionResult Add()
        {
            var vm = new SubcategoryFormModel
            {
                CategoryItems = _reefService.GetCategories().ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(SubcategoryFormModel model)
        {
            var subcategory = new Subcategory()
            {
                
            };
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            return View();
        }
     }
}