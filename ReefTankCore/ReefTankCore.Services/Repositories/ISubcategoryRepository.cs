using System;
using System.Collections.Generic;
using ReefTankCore.Core.Repositories;
using ReefTankCore.Models.Base;

namespace ReefTankCore.Services.Repositories
{
    public interface ISubcategoryRepository : IRepository<Subcategory>
    {
        Subcategory GetSubcategory(Guid id);
        Subcategory GetFirstSubcategory();
        IEnumerable<Subcategory> GetSubcategories(Guid id);
    }
}