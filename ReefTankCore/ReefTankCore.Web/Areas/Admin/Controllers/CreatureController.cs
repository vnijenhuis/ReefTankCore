using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReefTankCore.Models.Base;
using ReefTankCore.Services.Context;
using ReefTankCore.Web.Areas.Admin.Models;

namespace ReefTankCore.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CreatureController : Controller
    {
        private readonly IReefService _reefService;

        public CreatureController(IReefService reefService)
        {
            _reefService = reefService;
        }

        public IActionResult Edit(Guid id)
        {
            var creature = _reefService.GetCreature(id);
            
            var vm = Mapper.Map<Creature, CreatureDetailsModel>(creature);
            //vm.Logo = creature.Logo;

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(CreatureDetailsModel model)
        {
            var creature = _reefService.GetCreature(model.Id);
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            creature.CommonName = model.CommonName;
            creature.Description = model.Description;
            creature.Diet = model.Diet;
            creature.DifficultyDescription = model.DifficultyDescription;
            creature.Difficulty = model.Difficulty;
            creature.Genus = model.Genus;
            creature.Length = model.Length;
            creature.Origin = model.Origin;
            creature.ReefCompatability = model.ReefCompatability;
            creature.Species = model.Genus;
            creature.Temperament = model.Temperament;
            creature.Volume = model.Volume;
            creature.SpecialRequirements = model.SpecialRequirements;

            //Update creature image.
            if (model.Logo != null)
            {
                if (creature.Logo == null)
                {
                    creature.Logo = new Media() { CreatureId = creature.Id };
                }

                if (model.Logo.FileName != creature.Logo?.Filename)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        model.Logo.CopyToAsync(memoryStream);
                        creature.Logo.Image = memoryStream.ToArray();
                        creature.Logo.Filename = model.Logo.FileName;
                    }
                    _reefService.SaveMedia(creature.Logo);
                }
            }

            _reefService.SaveCreature(creature);

            return View(model);
        }
    }
}