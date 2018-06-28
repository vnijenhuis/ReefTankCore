using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ReefTankCore.Models.Base;
using ReefTankCore.Web.Areas.Admin.Models;
using ReefTankCore.Web.Areas.Admin.Models.Categories;
using ReefTankCore.Web.Areas.Admin.Models.Creatures;
using ReefTankCore.Web.Areas.Admin.Models.Subcategories;
using ReefTankCore.Web.Models;

namespace ReefTankCore.Web
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CATEGORY
            CreateMap<Category, CategoryViewModel>()
                .ForMember(x => x.Media, opt => opt.MapFrom(x => Mapper.Map<Media, MediaViewModel>(x.Media)));
            CreateMap<Category, CategoryIndexModel>()
                .ForMember(x => x.SubcategoryCount, opt => opt.MapFrom(x => x.Subcategories.Count));
            CreateMap<Category, CategoryDetailsModel>();
            CreateMap<Category, CategoryEditViewModel>()
                .ForMember(x => x.ContentUrl, opt => opt.MapFrom(x => x.Media.Url + x.Media.Filename))
                .ForMember(x => x.FileName, opt => opt.MapFrom(x => x.Media.Filename));

            //SUBCATEGORY
            CreateMap<Subcategory, SubcategoryViewModel>()
                .ForMember(x => x.Media, opt => opt.MapFrom(x => Mapper.Map<Media, MediaViewModel>(x.Media)));
            CreateMap<Subcategory, SubcategoryIndexModel>()
                .ForMember(x => x.CreatureCount, opt => opt.MapFrom(x => x.Creatures.Count));
            CreateMap<Subcategory, SubcategoryDetailsModel>();
            CreateMap<Subcategory, SubcategoryListViewModel>()
                .ForMember(x => x.Media, opt => opt.MapFrom(x => Mapper.Map<Media, MediaViewModel>(x.Media))); ;
            CreateMap<Subcategory, SubcategoryFormModel>();

            //CREATURE
            CreateMap<Creature, CreatureIndexModel>();
            CreateMap<Creature, CreatureDetailsModel>()
                .ForMember(x => x.FileName, opt => opt.MapFrom(x => x.Media.Filename))
                .ForMember(x => x.ReefCompatabilityItems, opt => opt.Ignore())
                .ForMember(x => x.TemperamentItems, opt => opt.Ignore())
                .ForMember(x => x.SpecialRequirementItems, opt => opt.Ignore())
                .ForMember(x => x.DifficultyItems, opt => opt.Ignore())
                .ForMember(x => x.SubcategoryItems, opt => opt.Ignore())
                .ForMember(x => x.SubcategoryId, opt => opt.MapFrom(x => x.Subcategory.Id))
                .ForMember(x => x.CategoryId, opt => opt.MapFrom(x => x.Subcategory.Category.Id))
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(x => x.Subcategory.Category.Name));
            CreateMap<Creature, CreatureViewModel>()
                .ForMember(x => x.FileName, opt => opt.MapFrom(x => x.Media.Url + x.Media.Filename))
                .ForMember(x => x.ReefCompatabilityItems, opt => opt.Ignore())
                .ForMember(x => x.TemperamentItems, opt => opt.Ignore())
                .ForMember(x => x.SpecialRequirementItems, opt => opt.Ignore())
                .ForMember(x => x.DifficultyItems, opt => opt.Ignore())
                .ForMember(x => x.SubcategoryItems, opt => opt.Ignore())
                .ForMember(x => x.SubcategoryId, opt => opt.MapFrom(x => x.Subcategory.Id))
                .ForMember(x => x.CategoryId, opt => opt.MapFrom(x => x.Subcategory.Category.Id))
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(x => x.Subcategory.Category.Name));

            //MEDIA
            CreateMap<Media, MediaViewModel>()
                .ForMember(x => x.ContentUrl , opt => opt.MapFrom(x => x.Url + x.Filename));

        }
    }
}
