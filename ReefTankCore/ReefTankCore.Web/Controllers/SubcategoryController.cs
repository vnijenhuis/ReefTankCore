using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReefTankCore.Models.Base;
using ReefTankCore.Services.Context;
using ReefTankCore.Web.Models;

namespace ReefTankCore.Web.Controllers
{
    public class SubcategoryController : Controller
    {
        private readonly IReefService _reefService;

        public SubcategoryController(IReefService reefService)
        {
            _reefService = reefService;
        }

        public IActionResult Index(Guid id)
        {
            var subcategory = _reefService.GetSubcategory(id);
            if (subcategory.Category.Slug != "corals")
            {
                
            }
            var creatures = _reefService.GetCreaturesBySubcategory(subcategory);
            //var vm = new SubcategoryOverviewViewModel
            //{
            //    Id = subcategory.Id,
            //    CommonName = subcategory.CommonName,
            //    Creatures = Mapper.Map<IEnumerable<Creature>, IList<CreatureViewModel>>(subcategories),
            //};
            //return View(vm);
            return null;
        }
    }
}