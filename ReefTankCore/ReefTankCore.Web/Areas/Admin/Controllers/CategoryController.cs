using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReefTankCore.Models.Base;
using ReefTankCore.Services.Context;
using ReefTankCore.Web.Areas.Admin.Models;

namespace ReefTankCore.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IReefService _reefService;

        public CategoryController(IReefService reefService)
        {
            _reefService = reefService;
        }

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
    }
}