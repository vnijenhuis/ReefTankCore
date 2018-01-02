using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReefTankCore.Models.Base;
using ReefTankCore.Services.Context;
using ReefTankCore.Web.Areas.Admin.Models;
using ReefTankCore.Web.Models;

namespace ReefTankCore.Web.Controllers
{
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        private readonly IReefService _reefService;
        private readonly ReefContext _reefContext;

        public CategoryController(IReefService reefService, ReefContext reefContext)
        {
            _reefService = reefService;
            _reefContext = reefContext;
        }

        public IActionResult Index(Guid id)
        {
            var category = _reefService.GetCategory(id);
            var subcategories = _reefService.GetSubcategories(category);
            var vm = new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Subcategories = Mapper.Map<IEnumerable<Subcategory>, IList<SubcategoryViewModel>>(subcategories),
            };
            return View(vm);
        }
        
    }
}