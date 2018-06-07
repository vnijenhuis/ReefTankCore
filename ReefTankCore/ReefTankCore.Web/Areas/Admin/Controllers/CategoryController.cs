using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReefTankCore.Models.Base;
using ReefTankCore.Services.Context;
using ReefTankCore.Web.Areas.Admin.Models.Categories;
using ReefTankCore.Web.Areas.Admin.Models.Subcategories;

namespace ReefTankCore.Web.Areas.Admin.Controllers
{
    public class CategoryController : AdminController
    {
        //private const string Directory = "/images/Categories/";
        private readonly IReefService _reefService;
        private readonly IMediaService _mediaService;

        public CategoryController(IReefService reefService, IMediaService mediaService)
        {
            _reefService = reefService;
            _mediaService = mediaService;
        }

        [HttpGet]
        [Route("Category/Index")]
        public IActionResult Index()
        {
            var categories = _reefService.GetCategories();
            var vm = new CategoryOverviewModel()
            {
                Categories = Mapper.Map<IEnumerable<Category>, IList<CategoryIndexModel>>(categories),
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var category = _reefService.GetCategory(id);

            var vm = Mapper.Map<Category, CategoryEditViewModel>(category);

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(CategoryEditViewModel model, IFormFile upload)
        {
            if (ModelState.IsValid)
            {
                var category = _reefService.GetCategory(model.Id);
                category.Description = model.Description;
                category.Name = model.Name;

                //File upload
                var dir = "/images/Categories/" + category.Name + "/";
                if (upload != null)
                {
                    if (category.Media == null || upload.FileName != category.Media?.Filename)
                    {
                        var media = _mediaService.InsertMedia(upload, dir);
                        //Delete old media.
                        if (category.Media != null)
                        {
                            _mediaService.Delete(category.Media);
                        }

                        //save new media.
                        category.Media = media;
                        category.MediaId = media.Id;
                    }
                }
                _reefService.SaveCategoryAsync(category);
                return RedirectToAction("Index", "Category", new { Area = "Admin"});
            }
            return View(model);
        }
    }
}