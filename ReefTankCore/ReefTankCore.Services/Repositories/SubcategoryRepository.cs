using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReefTankCore.Models;
using ReefTankCore.Models.Base;
using ReefTankCore.Services.Services;

namespace ReefTankCore.Services.Repositories
{
    public class SubcategoryRepository : Repository<Subcategory>, ISubcategoryRepository
    {
        private readonly IBaseRepository _baseRepository;

        public SubcategoryRepository(IBaseRepository baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public Subcategory GetSubcategory(Guid id)
        {
            return _baseRepository.Context.Subcategories.FirstOrDefault(x => x.Id == id);
        }

        public Subcategory GetFirstSubcategory()
        {
            return _baseRepository.Context.Subcategories.FirstOrDefault();
        }

        public IEnumerable<Subcategory> GetSubcategories(Guid id)
        {
            return _baseRepository.Context.Subcategories.BuildSubcategory().Where(x => x.CategoryId == id).ToList();
        }
    }
}
