using System;
using System.Collections.Generic;
using System.Text;
using ReefTankCore.Models.Base;
using ReefTankCore.Services.Services;

namespace ReefTankCore.Services.Repositories
{
    public class CreatureTagRepository : Repository<CreatureTag>, ICreatureTagRepository
    {
        private readonly IBaseRepository _baseRepository;
        public CreatureTagRepository(IBaseRepository baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}
