using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReefTankCore.Models.Base;
using ReefTankCore.Services.Context;
using ReefTankCore.Services.Repositories;
using ReefTankCore.Web.Areas.Admin.Models;
using ReefTankCore.Web.Models;

namespace ReefTankCore.Web.Controllers
{
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult Index(Guid id)
        {
            var category = _categoryRepository.GetCategory(id);
            var subcategories = category.Subcategories.ToList();

            var vm = Mapper.Map<Category, CategoryViewModel>(category);
            vm.Subcategories = Mapper.Map<IEnumerable<Subcategory>, IList<SubcategoryListViewModel>>(subcategories);

            return View(vm);
        }
        
    }
}