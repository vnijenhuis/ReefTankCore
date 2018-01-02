using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReefTankCore.Models.Base;
using ReefTankCore.Services.Context;
using ReefTankCore.Web.Areas.Admin.Models;
using ReefTankCore.Web.Models;

namespace ReefTankCore.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IReefService _reefService;

        public HomeController(IReefService reefService)
        {
            _reefService = reefService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Category");
        }
    }
}