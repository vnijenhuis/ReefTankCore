using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReefTankCore.Core.Repositories;
using ReefTankCore.Models.Base;

namespace ReefTankCore.Services.Repositories
{
    public interface ICreatureRepository : IRepository<Creature>
    {
        Creature GetCreature(Guid id);
        Task<Creature> GetCreatureAsync(Guid id);
        IEnumerable<Creature> GetCreatures();
        IEnumerable<Creature> GetCreaturesByCategory(Category category);
        IEnumerable<Creature> GetCreaturesBySubcategory(Subcategory subcategory);
        void SaveCreatureTag(CreatureTag creatureTag);
        void SaveCreatureTagAsync(CreatureTag creatureTag);
        void SaveCreatureReference(CreatureReference creatureReference);
        void DeleteCreatureTag(CreatureTag tag);
    }
}