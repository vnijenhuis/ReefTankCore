using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReefTankCore.Models.Base;
using ReefTankCore.Services.Context;
using ReefTankCore.Web.Areas.Admin.Models.Categories;
using ReefTankCore.Web.Areas.Admin.Models.Creatures;
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
            var subcategory = _reefService.GetSubcategory(id) ?? _reefService.GetFirstSubcategory();

            var vm = Mapper.Map<Subcategory, SubcategoryDetailsModel>(subcategory);
            vm.Creatures = Mapper.Map<IEnumerable<Creature>, IList<CreatureIndexModel>>(subcategory.Creatures);

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