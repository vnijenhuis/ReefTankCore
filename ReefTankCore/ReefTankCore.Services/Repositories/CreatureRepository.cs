using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReefTankCore.Models;
using ReefTankCore.Models.Base;
using ReefTankCore.Services.Context;
using ReefTankCore.Services.Services;

namespace ReefTankCore.Services.Repositories
{
    /// <summary>
    /// A repository that works with Creature entities.
    /// </summary>
    public class CreatureRepository : Repository<Creature>, ICreatureRepository
    {
        private readonly IBaseRepository _baseRepository;

        public CreatureRepository(IBaseRepository baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public IEnumerable<Creature> GetCreatures()
        {
            var creatures = _baseRepository.Context.Creatures
                .BuildCreature();

            return creatures;
        }

        public Creature GetCreature(Guid id)
        {
            var creature = _baseRepository.Context.Creatures
                .BuildCreature()
                .FirstOrDefault(x => x.Id == id);

            return creature;
        }

        public async Task<Creature> GetCreatureAsync(Guid id)
        {
            var creature = await _baseRepository.Context.Creatures
                .BuildCreature()
                .FirstOrDefaultAsync(x => x.Id == id);

            return creature;
        }

        public IEnumerable<Creature> GetCreaturesByCategory(Category category)
        {
            var creatures = _baseRepository.Context.Creatures
                .BuildCreature()
                .Where(x => x.Subcategory.Category.Id == category.Id);

            return creatures;
        }

        public IEnumerable<Creature> GetCreaturesBySubcategory(Subcategory subcategory)
        {
            var creatures = _baseRepository.Context.Creatures
                .BuildCreature()
                .Where(x => x.Subcategory.Id == subcategory.Id);

            return creatures;
        }

        public void SaveCreatureTag(CreatureTag creatureTag)
        {
            _baseRepository.Context.CreatureTags.Add(creatureTag);
        }

        public void SaveCreatureTagAsync(CreatureTag creatureTag)
        {
            throw new NotImplementedException();
        }

        public void SaveCreatureReference(CreatureReference creatureReference)
        {
            _baseRepository.Context.CreatureReferences.Add(creatureReference);
        }

        public void DeleteCreatureTag(CreatureTag creatureTag)
        {
            _baseRepository.Context.CreatureTags.Remove(creatureTag);
        }
    }
}
