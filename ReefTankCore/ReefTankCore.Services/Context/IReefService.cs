using System;
using System.Collections.Generic;
using ReefTankCore.Models.Base;
using ReefTankCore.Models.Corals;
using ReefTankCore.Models.Inhabitants;

namespace ReefTankCore.Services.Context
{
    public interface IReefService
    {
        Inhabitant GetInhabitant(Guid id);
        IEnumerable<Inhabitant> GetInhabitants();
        IEnumerable<Inhabitant> GetInhabitantsByCategory(Category category);
        IEnumerable<Inhabitant> GetInhabitantsBySubcategory(Subcategory subcategory);

        Coral GetCoral(Guid id);
        IEnumerable<Coral> GetCorals();
        IEnumerable<Coral> GetCoralsByCategory(Category category);
        IEnumerable<Coral> GetCoralsBySubcategory(Subcategory subcategory);

        Category GetCategory(Guid id);
        IEnumerable<Category> GetCategories();

        Subcategory GetSubcategory(Guid id);
        IEnumerable<Subcategory> GetSubcategories(Category category);

    }
}
