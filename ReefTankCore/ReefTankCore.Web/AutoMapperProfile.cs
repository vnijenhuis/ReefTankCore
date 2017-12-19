using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ReefTankCore.Models.Base;
using ReefTankCore.Web.Areas.Admin.Models;
using ReefTankCore.Web.Models;

namespace ReefTankCore.Web
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Category, CategoryIndexModel>();
            CreateMap<Category, CategoryDetailsModel>();

            CreateMap<Subcategory, SubcategoryViewModel>();
            CreateMap<Subcategory, SubcategoryIndexModel>()
                .ForMember(x => x.CreatureCount, opt => opt.MapFrom(x => x.Creatures.Count));
            CreateMap<Subcategory, SubcategoryDetailsModel>();


            CreateMap<Creature, CreatureIndexModel>();
            CreateMap<Creature, CreatureDetailsModel>()
                .ForMember(x => x.SubcategorySlug, opt => opt.MapFrom(x => x.Subcategory.Slug))
                .ForMember(x => x.CategorySlug, opt => opt.MapFrom(x => x.Subcategory.Category.Slug));
        }
    }
}
