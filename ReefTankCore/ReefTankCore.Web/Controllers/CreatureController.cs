using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReefTankCore.Models.Base;
using ReefTankCore.Services.Repositories;
using ReefTankCore.Web.Models;

namespace ReefTankCore.Web.Controllers
{
    public class CreatureController : BaseController
    {
        private readonly ICreatureRepository _creatureRepository;

        public CreatureController(ICreatureRepository creatureRepository)
        {
            _creatureRepository = creatureRepository;
        }

        public IActionResult Index(Guid id)
        {
            var creature = _creatureRepository.GetCreature(id);

            var vm = Mapper.Map<Creature, CreatureViewModel>(creature);

            return View(vm);
        }
    }
}