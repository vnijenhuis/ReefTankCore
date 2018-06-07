using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReefTankCore.Models.Base;
using ReefTankCore.Services.Context;
using ReefTankCore.Web.Areas.Admin.Models;
using ReefTankCore.Web.Areas.Admin.Models.Categories;
using ReefTankCore.Web.Models;

namespace ReefTankCore.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Category");
        }
    }
}