using System;
using System.Collections.Generic;
using System.Text;
using ReefTankCore.Models.Base;
using ReefTankCore.Services.Services;

namespace ReefTankCore.Services.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        private readonly IBaseRepository _baseRepository;
        public TagRepository(IBaseRepository baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}
