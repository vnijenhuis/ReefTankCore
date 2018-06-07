using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReefTankCore.Models;
using ReefTankCore.Models.Base;
using ReefTankCore.Services.Services;

namespace ReefTankCore.Services.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly IBaseRepository _baseRepository;

        public CategoryRepository(IBaseRepository baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public Category GetCategory(Guid id)
        {
            return _baseRepository.Context.Categories
                .BuildCategory()
                .FirstOrDefault(x => x.Id == id);
        }

        public Category GetFirstCategory()
        {
            return _baseRepository.Context.Categories
                .BuildCategory()
                .FirstOrDefault();
        }
    }
}
