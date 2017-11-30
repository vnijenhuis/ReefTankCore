using System;
using System.Collections.Generic;
using System.Linq;
using ReefTankCore.Models.Base;
using ReefTankCore.Models.Corals;
using ReefTankCore.Models.Inhabitants;
using ReefTankCore.Services.Context;

namespace ReefTankCore.Services
{
    public class ReefService : IReefService
    {
        private readonly ReefContext _reefContext;

        public ReefService(ReefContext reefContext)
        {
            _reefContext = reefContext;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _reefContext.Categories.ToList();
        }

        public Subcategory GetSubcategory(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Coral> GetCoralsBySubcategory(Subcategory subcategory)
        {
            return _reefContext.Corals.Where(x => x.Subcategory.Id == subcategory.Id);
        }

        public Category GetCategory(Guid id)
        {
            return _reefContext.Categories.Find(id);
        }

        public IEnumerable<Inhabitant> GetInhabitants()
        {
            return _reefContext.Inhabitants;
        }

        public Inhabitant GetInhabitant(Guid id)
        {
            return _reefContext.Inhabitants.Find(id);
        }

        public IEnumerable<Inhabitant> GetInhabitantsByCategory(Category category)
        {
            return _reefContext.Inhabitants.Where(x => x.Subcategory.Category.Id == category.Id);
        }

        public IEnumerable<Inhabitant> GetInhabitantsBySubcategory(Subcategory subcategory)
        {
            return _reefContext.Inhabitants.Where(x => x.Subcategory.Id == subcategory.Id);
        }

        public Coral GetCoral(Guid id)
        {
            return _reefContext.Corals.Find(id);
        }

        public IEnumerable<Coral> GetCorals()
        {
            return _reefContext.Corals;
        }

        public IEnumerable<Coral> GetCoralsByCategory(Category category)
        {
            return _reefContext.Corals.Where(x => x.Subcategory.Category.Id == category.Id);
        }

        public IEnumerable<Subcategory> GetSubcategories(Category category)
        {
            return _reefContext.Subcategories.Where(x => x.Category.Id == category.Id);
        }
    }
}