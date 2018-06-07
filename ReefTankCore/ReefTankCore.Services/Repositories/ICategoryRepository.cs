using System;
using System.Collections.Generic;
using ReefTankCore.Core.Repositories;
using ReefTankCore.Models.Base;

namespace ReefTankCore.Services.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetCategory(Guid id);
        Category GetFirstCategory();
    }
}