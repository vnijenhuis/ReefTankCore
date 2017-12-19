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
    public class SubcategoryController : Controller
    {
        private readonly IReefService _reefService;

        public SubcategoryController(IReefService reefService)
        {
            _reefService = reefService;
        }

        public IActionResult Index(string slug)
        {
            var subcategory = _reefService.GetSubcategory(slug) ?? _reefService.GetFirstSubcategory();

            var vm = Mapper.Map<Subcategory, SubcategoryDetailsModel>(subcategory);
            vm.Creatures = Mapper.Map<IEnumerable<Creature>, IList<CreatureIndexModel>>(subcategory.Creatures);
            return View(vm);
        }
    }
}