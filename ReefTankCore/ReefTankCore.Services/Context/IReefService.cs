using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReefTankCore.Models.Base;
using ReefTankCore.Models.Enums;

namespace ReefTankCore.Services.Context
{
    public interface IReefService
    {
        Creature GetCreature(Guid id);
        Task<Creature> GetCreatureAsync(Guid id);
        IEnumerable<Creature> GetCreatures();
        IEnumerable<Creature> GetCreaturesByCategory(Category category);
        IEnumerable<Creature> GetCreaturesBySubcategory(Subcategory subcategory);
        void SaveCreature(Creature creature);
        Task SaveCreatureAsync(Creature creature);

        Category GetCategory(Guid id);
        Category GetCategory(string slug);
        IEnumerable<Category> GetCategories();

        Subcategory GetSubcategory(Guid id);
        Subcategory GetSubcategory(string slug);
        IEnumerable<Subcategory> GetAllSubcategories();
        IEnumerable<Subcategory> GetSubcategories(Category category);

        Subcategory GetFirstSubcategory();
        Category GetFirstCategory();

        void SaveMedia(Media media);
        Media GetImage(Guid id);

        IEnumerable<Tag> GetTags();
        IEnumerable<CreatureTag> GetCreatureTags(Creature creature);
        void DeleteCreatureTag(CreatureTag tag);
        void SaveCreatureTag(CreatureTag creatureTag);
    }
}
