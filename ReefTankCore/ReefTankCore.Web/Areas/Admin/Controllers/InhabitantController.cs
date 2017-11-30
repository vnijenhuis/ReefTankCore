using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReefTankCore.Models.Base;
using ReefTankCore.Services.Context;
using ReefTankCore.Web.Models;

namespace ReefTankCore.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InhabitantController : Controller
    {
        private readonly IReefService _reefService;

        public InhabitantController(IReefService reefService)
        {
            _reefService = reefService;
        }

        public IActionResult Index()
        {
            var categories = _reefService.GetCategories();
            var vm = Mapper.Map<IEnumerable<Category>, IList<CategoryViewModel>>(categories);
            return View(vm);
        }

        public IActionResult GetSubcategories(Guid id)
        {
            var category = _reefService.GetCategory(id);
            var subcategories = _reefService.GetSubcategories(category);
            
            return null;
        }

        public IActionResult GetInhabitants(Guid id)
        {
            var subcategory = _reefService.GetSubcategory(id);
            var inhabitants = _reefService.GetInhabitantsBySubcategory(subcategory);

            return null;
        }

        public IActionResult Details(Guid id)
        {
            var inhabitant = _reefService.GetInhabitant(id);
            return null;
        }

        public IActionResult Edit(Guid id)
        {
            var inhabitant = _reefService.GetInhabitant(id);
            return null;
        }

        [HttpPost]
        public IActionResult Edit()
        {
            return null;
        }

        public IActionResult New()
        {
            return null;
        }

        public IActionResult Delete(Guid id)
        {
            var inhabitant = _reefService.GetInhabitant(id);
            return null;
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return null;
        }
    }
}