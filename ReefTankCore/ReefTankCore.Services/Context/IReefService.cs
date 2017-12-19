using System;
using System.Collections.Generic;
using ReefTankCore.Models.Base;

namespace ReefTankCore.Services.Context
{
    public interface IReefService
    {
        Creature GetCreature(Guid id);
        IEnumerable<Creature> GetCreatures();
        IEnumerable<Creature> GetCreaturesByCategory(Category category);
        IEnumerable<Creature> GetCreaturesBySubcategory(Subcategory subcategory);
        void SaveCreature(Creature creature);

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
    }
}
