using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReefTankCore.Models.Base;
using ReefTankCore.Models.Enums;
using ReefTankCore.Services.Context;
using ReefTankCore.Web.Areas.Admin.Models.Creatures;
using ReefTankCore.Web.Areas.Admin.Models.Subcategories;
using ReefTankCore.Web.Helpers;

namespace ReefTankCore.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CreatureController : Controller
    {
        private readonly IReefService _reefService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public CreatureController(IReefService reefService, IHostingEnvironment hostingEnvironment)
        {
            _reefService = reefService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index(string slug)
        {
            var subcategory = _reefService.GetSubcategory(slug) ?? _reefService.GetFirstSubcategory();

            var vm = Mapper.Map<Subcategory, SubcategoryDetailsModel>(subcategory);
            vm.Creatures = Mapper.Map<IEnumerable<Creature>, IList<CreatureIndexModel>>(subcategory.Creatures);

            return View(vm);
        }

        public IActionResult Add(Guid id)
        {
            var subcategory = _reefService.GetSubcategory(id);

            var vm = new CreatureDetailsModel()
            {
                SubcategorySlug = subcategory.Slug,
                SubcategoryCommonName = subcategory.CommonName,
                SubcategoryId = subcategory.Id,
                CategorySlug = subcategory.Category.Slug,
            };
            vm = GetCreatureModel(null, vm);

            return View(vm);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var creature = await _reefService.GetCreatureAsync(id);

            var vm = Mapper.Map<Creature, CreatureDetailsModel>(creature);
            vm = GetCreatureModel(creature, vm);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreatureDetailsModel model, IFormFile upload)
        {
            var creature = await _reefService.GetCreatureAsync(model.Id);
            if (!ModelState.IsValid)
            {
                model = GetCreatureModel(creature, model);
                return View(model);
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

            //Update creature image.
            if (upload != null)
            {
                var webRoot = _hostingEnvironment.WebRootPath + "/images/Creatures/";

                var path = Path.Combine(webRoot, upload.FileName);
                if (!System.IO.File.Exists(path))
                {
                    using (var fs = System.IO.File.Create(path))
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
                        CreatureId = creature.Id,
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

            var creatureTags = _reefService.GetCreatureTags(creature).ToList();

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
                    _reefService.DeleteCreatureTag(tag);
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

                    _reefService.SaveCreatureTag(creatureTag);
                }
            }

            await _reefService.SaveCreatureAsync(creature);

            return RedirectToAction("Index", "Subcategory", new { Area = "Admin", Slug = model.SubcategorySlug });
        }

        private static List<SelectListItem> GetReefCompatability()
        {
            var list = new List<SelectListItem>();

            foreach (ReefCompatability reefCompatability in Enum.GetValues(typeof(ReefCompatability)))
            {
                list.Add(new SelectListItem
                {
                    Text = EnumHelper<ReefCompatability>.GetDisplayValue(reefCompatability),
                    Value = reefCompatability.ToString()
                });
            }

            return list;
        }

        private static List<SelectListItem> GetTemperament()
        {
            var list = new List<SelectListItem>();

            foreach (Temperament temperament in Enum.GetValues(typeof(Temperament)))
            {
                list.Add(new SelectListItem
                {
                    Text = EnumHelper<Temperament>.GetDisplayValue(temperament),
                    Value = temperament.ToString()
                });
            }

            return list;
        }

        private static List<SelectListItem> GetDifficulties()
        {
            var list = new List<SelectListItem>();

            foreach (Difficulty difficulty in Enum.GetValues(typeof(Difficulty)))
            {
                list.Add(new SelectListItem
                {
                    Text = EnumHelper<Difficulty>.GetDisplayValue(difficulty),
                    Value = difficulty.ToString()
                });
            }

            return list;
        }

        private static List<SelectListItem> GetSpecialRequirements()
        {
            var list = new List<SelectListItem>();

            foreach (SpecialRequirements specialRequirements in Enum.GetValues(typeof(SpecialRequirements)))
            {
                list.Add(new SelectListItem
                {
                    Text = EnumHelper<SpecialRequirements>.GetDisplayValue(specialRequirements),
                    Value = specialRequirements.ToString()
                });
            }

            return list;
        }

        private static List<SelectListItem> GetTagTypes()
        {
            var list = new List<SelectListItem>();

            foreach (TagType tagType in Enum.GetValues(typeof(TagType)))
            {
                list.Add(new SelectListItem
                {
                    Text = EnumHelper<TagType>.GetDisplayValue(tagType),
                    Value = tagType.ToString()
                });
            }

            return list;
        }

        private CreatureDetailsModel GetCreatureModel(Creature creature, CreatureDetailsModel vm)
        {
            var category = _reefService.GetCategory(vm.CategorySlug);
            vm.SubcategoryItems = _reefService.GetSubcategories(category).ToList();
            vm.DifficultyItems = GetDifficulties();
            vm.ReefCompatabilityItems = GetReefCompatability();
            vm.SpecialRequirementItems = GetSpecialRequirements();
            vm.TemperamentItems = GetTemperament();
            vm.TagList = new Guid[0];
            vm.TagItems = new List<TagTypeViewModel>();

            var tagsByTagType = _reefService.GetTags().GroupBy(x => EnumHelper<TagType>.GetDisplayValue(x.TagType));

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

        public IActionResult Delete(Guid id)
        {

            var creature = _reefService.GetCreature(id);

            var vm = new DeleteCreatureViewModel()
            {
                CommonName = creature.CommonName,
                Subcategory = creature.Subcategory.CommonName,
                Genus = creature.Genus,
                Species = creature.Species,
            };

            return View(vm);
        }
    }
}