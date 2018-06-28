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
    public class SubcategoryController : BaseController
    {
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly ICreatureRepository _creatureRepository;
        public SubcategoryController(ISubcategoryRepository subcategoryRepository, ICreatureRepository creatureRepository)
        {
            _subcategoryRepository = subcategoryRepository;
            _creatureRepository = creatureRepository;
        }

        public IActionResult Index(Guid id)
        {
            var subcategory = _subcategoryRepository.GetSubcategory(id);
            var creatures = _creatureRepository.GetCreaturesBySubcategory(subcategory);

            var vm = new SubcategoryViewModel()
            {
                Id = subcategory.Id,
                CommonName = subcategory.CommonName,
                ScientificName = subcategory.ScientificName,
                Description = subcategory.Description,
                Creatures = Mapper.Map<IEnumerable<Creature>, IList<CreatureViewModel>>(creatures),
            };
            return View(vm);
        }
    }
}