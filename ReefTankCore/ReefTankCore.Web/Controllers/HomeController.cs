﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReefTankCore.Models.Base;
using ReefTankCore.Services;
using ReefTankCore.Services.Context;
using ReefTankCore.Web.Data;
using ReefTankCore.Web.Models;
namespace ReefTankCore.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    [ViewComponent(Name = "CategoryMenu")]
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly DbContextOptions<ReefContext> _reefContext;

        public CategoryMenuViewComponent(DbContextOptions<ReefContext> reefContext)
        {
            _reefContext = reefContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var context = new ReefContext(_reefContext);
            IEnumerable<Category> mc = await context.Categories.ToListAsync();
            var vm = Mapper.Map<IEnumerable<Category>, IList<CategoryViewModel>>(mc).OrderBy(x => x.Name);
            return View("CategoryMenu", vm);
        }
    }
}

