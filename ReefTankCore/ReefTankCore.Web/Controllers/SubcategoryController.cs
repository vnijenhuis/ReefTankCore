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
using ReefTankCore.Web.Models;

namespace ReefTankCore.Web.Controllers
{
    [AllowAnonymous]
    public class SubcategoryController : Controller
    {
        private readonly ISubcategoryRepository _subcategoryRepository;
        public SubcategoryController(ISubcategoryRepository subcategoryRepository)
        {
            _subcategoryRepository = subcategoryRepository;
        }

        public IActionResult Index(Guid id)
        {
            var subcategory = _subcategoryRepository.GetSubcategory(id);
            var vm = new SubcategoryViewModel()
            {
                Id = subcategory.Id,
                CommonName = subcategory.CommonName,
                ScientificName = subcategory.ScientificName,
                Description = subcategory.Description,
                Creatures = Mapper.Map<IEnumerable<Creature>, IList<CreatureViewModel>>(subcategory.Creatures),
            };
            return View(vm);
        }
    }
}