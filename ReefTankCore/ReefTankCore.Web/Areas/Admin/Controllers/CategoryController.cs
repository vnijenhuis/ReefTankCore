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
using ReefTankCore.Web.Areas.Admin.Models.Subcategories;

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
    }
}