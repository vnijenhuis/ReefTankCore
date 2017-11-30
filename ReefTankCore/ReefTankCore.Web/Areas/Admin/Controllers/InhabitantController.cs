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
    }
}