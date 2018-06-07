using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReefTankCore.Models.Base;
using ReefTankCore.Services.Context;
using ReefTankCore.Services.Repositories;
using ReefTankCore.Web.Areas.Admin.Models.Categories;
using ReefTankCore.Web.Areas.Admin.Models.Creatures;
using ReefTankCore.Web.Areas.Admin.Models.Subcategories;
using ReefTankCore.Web.Models;

namespace ReefTankCore.Web.Areas.Admin.Controllers
{
    public class SubcategoryController : AdminController
    {
        private readonly IMediaService _mediaService;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubcategoryRepository _subcategoryRepository;

        public SubcategoryController( IMediaService mediaService, ICategoryRepository categoryRepository, ISubcategoryRepository subcategoryRepository)
        {
            _mediaService = mediaService;
            _categoryRepository = categoryRepository;
            _subcategoryRepository = subcategoryRepository;
        }

        [HttpGet]
        public IActionResult Index(Guid id)
        {
            var category = _categoryRepository.GetCategory(id) ?? _categoryRepository.GetFirstCategory();
            var subcategories = _subcategoryRepository.GetSubcategories(category.Id).ToList();
            var vm = new CategoryDetailsModel()
            {
                Id = category.Id,
                Name = category.Name,
                Slug = category.Slug,
                Subcategories = Mapper.Map<IEnumerable<Subcategory>, IList<SubcategoryIndexModel>>(subcategories),
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var vm = new SubcategoryFormModel
            {
                CategoryItems = _categoryRepository.FindAll().ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(SubcategoryFormModel model, IFormFile upload)
        {
            if (ModelState.IsValid)
            {
                var subcategory = new Subcategory()
                {
                    Category = _categoryRepository.GetCategory(model.CategoryId),
                    CategoryId = model.CategoryId,
                    CommonName = model.CommonName,
                    Description = model.Description,
                    ScientificName = model.ScientificName,
                    Slug = model.Slug,
                };
                subcategory = SaveImage(upload, subcategory);

                _subcategoryRepository.Save(subcategory);

                return RedirectToAction("Index", model.CategoryId);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var subcategory = _subcategoryRepository.GetSubcategory(id);

            var vm = Mapper.Map<Subcategory, SubcategoryFormModel>(subcategory);
            vm.CategoryItems = _categoryRepository.FindAll().ToList();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(SubcategoryFormModel model, IFormFile upload)
        {
            if (ModelState.IsValid)
            {
                var subcategory = _subcategoryRepository.GetSubcategory(model.Id);

                subcategory = SaveImage(upload, subcategory);
                _subcategoryRepository.Save(subcategory);

                return RedirectToAction("Index", model.CategoryId);
            }

            model.CategoryItems = _categoryRepository.FindAll().ToList();
            return View(model);
        }

        private Subcategory SaveImage(IFormFile upload, Subcategory subcategory)
        {
            //File upload
            var dir = "/images/Categories/" + subcategory.Category.Name + "/" + subcategory.CommonName + "/";
            if (upload != null)
            {
                if (subcategory.Media == null || upload.FileName != subcategory.Media?.Filename)
                {
                    var media = _mediaService.InsertMedia(upload, dir);
                    subcategory.Media = media;
                }
            }
            return subcategory;
        }
    }
}