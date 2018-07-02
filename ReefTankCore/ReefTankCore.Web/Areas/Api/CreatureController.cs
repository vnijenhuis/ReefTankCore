using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReefTankCore.Models.Base;
using ReefTankCore.Models.Enums;
using ReefTankCore.Services.Context;
using ReefTankCore.Services.Repositories;
using ReefTankCore.Web.Areas.Admin.Models.Creatures;
using ReefTankCore.Web.Controllers;
using ReefTankCore.Web.Helpers;

namespace ReefTankCore.Web.Areas.Api
{
    [Area("Api")]
    public class CreatureController
    {
        private readonly IEnumService _enumService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ICreatureRepository _creatureRepository;
        private readonly ICreatureTagRepository _creatureTagRepository;
        private readonly ITagRepository _tagRepository;

        public CreatureController(IEnumService enumService, IHostingEnvironment hostingEnvironment, ICreatureRepository creatureRepository, ICreatureTagRepository creatureTagRepository, ITagRepository tagRepository)
        {
            _enumService = enumService;
            _hostingEnvironment = hostingEnvironment;
            _creatureRepository = creatureRepository;
            _creatureTagRepository = creatureTagRepository;
            _tagRepository = tagRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var creatures = await _creatureRepository.GetCreaturesAsync();

            var model = Mapper.Map<IEnumerable<Creature>, IEnumerable<CreatureDetailsModel>>(creatures);

            return new JsonResult(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var creature = await _creatureRepository.GetCreatureAsync(id);

            var vm = Mapper.Map<Creature, CreatureDetailsModel>(creature);
            vm = GetCreatureModel(creature, vm);

            return new JsonResult(vm);
        }

        [HttpPost]
        public async void Post(Guid? id, [FromBody] CreatureDetailsModel model, IFormFile upload)
        {
            var creature = new Creature();
            if (id.HasValue)
            {
                creature = await _creatureRepository.GetCreatureAsync(id.Value);
            }
            creature.CommonName = model.CommonName;
            creature.Description = model.Description;
            creature.Diet = model.Diet;
            creature.DifficultyDescription = model.DifficultyDescription;
            creature.Difficulty = model.Difficulty;
            creature.Genus = model.Genus;
            creature.Species = model.Species;
            creature.Length = model.Length;
            creature.Origin = model.Origin;
            creature.ReefCompatability = model.ReefCompatability;
            creature.Temperament = model.Temperament;
            creature.Volume = model.Volume;
            creature.SpecialRequirements = model.SpecialRequirements;
            creature.SubcategoryId = model.SubcategoryId;

            //Update creature image.
            if (upload != null)
            {
                var webRoot = _hostingEnvironment.WebRootPath + "/images/Creatures/";

                var path = Path.Combine(webRoot, upload.FileName);
                if (!File.Exists(path))
                {
                    using (var fs = File.Create(path))
                    {
                        upload.CopyTo(fs);
                        fs.Flush();
                        fs.Close();
                    }
                }

                if (creature.Media == null)
                {
                    var media = new Media()
                    {
                        ContentType = upload.ContentType,
                        Filename = upload.FileName,
                    };
                    creature.Media = media;
                }

                if (upload.FileName != creature.Media?.Filename)
                {
                    creature.Media.ContentType = upload.ContentType;
                    creature.Media.Filename = upload.FileName;
                }
            }

            var creatureTags = _creatureTagRepository.GetCreatureTags(creature).ToList();

            if (creatureTags.Any())
            {
                var itemsToDelete = new List<CreatureTag>();

                if (model.TagList != null && model.TagList.Any())
                {
                    itemsToDelete =
                        creatureTags.Where(x => !model.TagList.Contains(x.TagId)).ToList();
                }

                foreach (var tag in itemsToDelete)
                {
                    _creatureTagRepository.Remove(tag);
                    creatureTags.Remove(tag);
                }
            }

            if (model.TagList != null)
            {
                // Check which tags are already coupled to this creature and which tags stay coupled. these can be ignored. 
                var newTagIds = model.TagList.Where(x => creatureTags.All(sa => sa.TagId != x));

                //Couple checked activities to the student group.
                foreach (var tagId in newTagIds)
                {
                    var creatureTag = new CreatureTag()
                    {
                        CreatureId = creature.Id,
                        TagId = tagId,
                    };

                    _creatureTagRepository.Save(creatureTag);
                }
            }

            _creatureRepository.Save(creature);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var creature = _creatureRepository.GetCreatureAsync(id);

            if (creature != null)
            {
                await Task.Run(() => _creatureRepository.RemoveAsync(creature.Result));
                return new JsonResult("Creature deleted.");
            }

            return new JsonResult("Creature cannot be deleted.");
        }
        
        private CreatureDetailsModel GetCreatureModel(Creature creature, CreatureDetailsModel vm)
        {
            vm.DifficultyItems = _enumService.GetDifficulties();
            vm.ReefCompatabilityItems = _enumService.GetReefCompatability();
            vm.SpecialRequirementItems = _enumService.GetSpecialRequirements();
            vm.TemperamentItems = _enumService.GetTemperament();
            vm.TagList = new Guid[0];
            vm.TagItems = new List<TagTypeViewModel>();

            var tagsByTagType = _tagRepository.FindAll().GroupBy(x => EnumHelper<TagType>.GetDisplayValue(x.TagType));

            foreach (var tagType in tagsByTagType)
            {
                var tagtypeModel = new TagTypeViewModel()
                {
                    Name = tagType.Key,
                    Tags = tagType.Select(x => x).ToList(),
                };
                vm.TagItems.Add(tagtypeModel);
            }

            if (creature != null)
            {
                if (creature.CreatureTags.Any())
                {
                    vm.TagList = new Guid[creature.CreatureTags.Count];
                }

                var index = 0;
                foreach (var creatureTag in creature.CreatureTags)
                {
                    vm.TagList[index] = creatureTag.TagId;
                    index++;
                }
            }

            return vm;
        }
    }
}