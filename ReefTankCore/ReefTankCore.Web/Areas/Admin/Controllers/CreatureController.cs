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
using ReefTankCore.Services.Repositories;
using ReefTankCore.Web.Areas.Admin.Models.Creatures;
using ReefTankCore.Web.Areas.Admin.Models.Subcategories;
using ReefTankCore.Web.Helpers;

namespace ReefTankCore.Web.Areas.Admin.Controllers
{
    public class CreatureController : AdminController
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IEnumService _enumService;
        private readonly IMediaService _mediaService;
        private readonly ICreatureRepository _creatureRepository;
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITagRepository _tagRepository;
        private readonly ICreatureTagRepository _creatureTagRepository;
        private const string Directory = "/images/Creatures/";

        public CreatureController(IHostingEnvironment hostingEnvironment, IEnumService enumService, IMediaService mediaService, ICreatureRepository creatureRepository, ISubcategoryRepository subcategoryRepository, ICategoryRepository categoryRepository, ITagRepository tagRepository, ICreatureTagRepository creatureTagRepository)
        {
            _hostingEnvironment = hostingEnvironment;
            _enumService = enumService;
            _mediaService = mediaService;
            _creatureRepository = creatureRepository;
            _subcategoryRepository = subcategoryRepository;
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
            _creatureTagRepository = creatureTagRepository;
        }

        [HttpGet]
        public IActionResult Index(Guid id)
        {
            var subcategory = _subcategoryRepository.GetSubcategory(id) ?? _subcategoryRepository.GetFirstSubcategory();

            var vm = Mapper.Map<Subcategory, SubcategoryDetailsModel>(subcategory);
            vm.Creatures = Mapper.Map<IEnumerable<Creature>, IList<CreatureIndexModel>>(_creatureRepository.GetCreatures().ToList());

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create(Guid id)
        {
            var subcategory = _subcategoryRepository.GetSubcategory(id);

            var vm = new CreatureDetailsModel()
            {
                SubcategoryId = subcategory.Id,
                SubcategoryCommonName = subcategory.CommonName,
                CategoryId = subcategory.Category.Id,
                CategoryName = subcategory.Category.Name,
            };

            vm = GetCreatureModel(null, vm);

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(CreatureDetailsModel model, IFormFile upload)
        {
            var creature = new Creature();

            if (!ModelState.IsValid)
            {
                model = GetCreatureModel(creature, model);
                return View(model);
            }

             SaveCreatureData(creature, model, upload);

            return RedirectToAction("Index", "Creature", new { Area = "Admin", Id = model.SubcategoryId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var creature = await _creatureRepository.GetCreatureAsync(id);

            var vm = Mapper.Map<Creature, CreatureDetailsModel>(creature);
            vm = GetCreatureModel(creature, vm);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreatureDetailsModel model, IFormFile upload)
        {
            if (!model.Id.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }

            var creature = await _creatureRepository.GetCreatureAsync(model.Id.Value);

            if (!ModelState.IsValid)
            {
                model = GetCreatureModel(creature, model);
                return View(model);
            }

            SaveCreatureData(creature, model, upload);

            return RedirectToAction("Index", "Creature", new { Area = "Admin", Id = model.SubcategoryId });
        }

        private CreatureDetailsModel GetCreatureModel(Creature creature, CreatureDetailsModel vm)
        {
            var category = _categoryRepository.GetCategory(vm.CategoryId);
            vm.SubcategoryItems = _subcategoryRepository.GetSubcategories(category.Id).ToList();
            vm.DifficultyItems = _enumService.GetDifficulties();
            vm.ReefCompatabilityItems = _enumService.GetReefCompatability();
            vm.SpecialRequirementItems = _enumService.GetSpecialRequirements();
            vm.TemperamentItems = _enumService.GetTemperament();

            vm.TagItems = new List<TagTypeViewModel>();

            var tagsByTagType = _tagRepository.FindAll().GroupBy(x => EnumHelper<TagType>.GetDisplayValue(x.TagType)).ToList();

            foreach (var tagType in tagsByTagType)
            {
                var tagtypeModel = new TagTypeViewModel()
                {
                    Name = tagType.Key,
                    Tags = tagType.Select(x => x).ToList(),
                };
                vm.TagItems.Add(tagtypeModel);
            }

            if (vm.TagList == null)
            {
                vm.TagList = new Guid[0];

                if (creature != null && creature.CreatureTags.Any())
                {
                    vm.TagList = creature.CreatureTags.Select(x => x.TagId).ToArray();
                }
            }

            return vm;
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var creature = _creatureRepository.GetCreatureAsync(id).Result;

            var vm = new DeleteCreatureViewModel()
            {
                Id = creature.Id,
                CommonName = creature.CommonName,
                Subcategory = creature.Subcategory.CommonName,
                SubcategoryId = creature.Subcategory.Id,
                Genus = creature.Genus,
                Species = creature.Species,
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(DeleteCreatureViewModel model)
        {
            var creature = _creatureRepository.GetCreature(model.Id);
            if (creature == null)
            {
                return RedirectToAction("Index", "Home", new { Area = "Admin"});
            }

            _creatureRepository.Remove(creature);

            return RedirectToAction("Index", "Creature", new { Id = model.SubcategoryId });
        }

        private void SaveCreatureData(Creature creature, CreatureDetailsModel model, IFormFile upload)
        {
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
                var webRoot = _hostingEnvironment.WebRootPath + Directory;

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
                        ContentType = upload.ContentType,
                        Filename = upload.FileName,
                        Url = Directory
                    };
                    creature.Media = media;
                }

                if (upload.FileName != creature.Media?.Filename)
                {
                    creature.Media.ContentType = upload.ContentType;
                    creature.Media.Filename = upload.FileName;
                    creature.Media.Url = Directory;
                }
            }

            var creatureTags = creature.CreatureTags.ToList();

            if (creatureTags.Any())
            {
                var itemsToDelete = new List<CreatureTag>();

                if (model.TagList != null && model.TagList.Any())
                {
                    itemsToDelete = creatureTags.Where(x => !model.TagList.Contains(x.TagId)).ToList();
                }

                foreach (var tag in itemsToDelete)
                {
                    _creatureRepository.DeleteCreatureTag(tag);
                    creatureTags.Remove(tag);
                }
            }

            if (model.TagList != null)
            {
                // Check which tags are already coupled to this creature and which tags stay coupled. these can be ignored. 
                var newTagIds = model.TagList.Where(x => creatureTags.All(sa => sa.TagId != x)).ToList();

                //Couple checked activities to the student group.
                foreach (var tagId in newTagIds)
                {
                    var creatureTag = new CreatureTag()
                    {
                        CreatureId = creature.Id,
                        TagId = tagId,
                    };

                    _creatureTagRepository.Add(creatureTag);
                }
            }

            _creatureRepository.Save(creature);
        }

        private Creature SaveImage(IFormFile upload, Creature creature)
        {
            //File upload
            var dir = "/images/Categories/" + creature.Subcategory.Category.Name + "/" + creature.Subcategory.CommonName + "/";
            if (upload != null)
            {
                if (creature.Media == null || upload.FileName != creature.Media?.Filename)
                {
                    var media = _mediaService.InsertMedia(upload, dir);
                    creature.Media = media;
                }
            }
            return creature;
        }
    }
}