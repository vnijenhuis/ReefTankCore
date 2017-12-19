using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReefTankCore.Models.Base;

namespace ReefTankCore.Services.Context
{
    public class ReefService : IReefService
    {
        private readonly ReefContext _reefContext;

        public ReefService(ReefContext reefContext)
        {
            _reefContext = reefContext;
        }

        public Category GetCategory(string slug)
        {
            var category = _reefContext.Categories
                .Include(x => x.Subcategories)
                .FirstOrDefault(x => x.Slug == slug);

            return category;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _reefContext.Categories.Include(x => x.Subcategories);
        }

        public Subcategory GetSubcategory(Guid id)
        {
            var subcategory = _reefContext.Subcategories.Find(id);
            return subcategory;
        }

        public Subcategory GetSubcategory(string slug)
        {
            var subcategory = _reefContext.Subcategories.FirstOrDefault(x => x.Slug == slug);
            LoadIntoSubcategory(subcategory);

            return subcategory;
        }

        public IEnumerable<Subcategory> GetAllSubcategories()
        {
            return _reefContext.Subcategories.Include(x => x.Creatures).Include(x => x.Category);
        }

        public void SaveCreature(Creature creature)
        {
            _reefContext.Creatures.Update(creature);
            _reefContext.SaveChangesAsync();
        }
        
        public Category GetCategory(Guid id)
        { 
            return _reefContext.Categories.Find(id);
        }

        public IEnumerable<Creature> GetCreatures()
        {
            var creatures = _reefContext.Creatures;
            LoadIntoCreatures(creatures);

            return creatures;
        }

        public Creature GetCreature(Guid id)
        {
            var creature = _reefContext.Creatures.Find(id);
            LoadIntoCreature(creature);

            return _reefContext.Creatures.Find(id);
        }

        public IEnumerable<Creature> GetCreaturesByCategory(Category category)
        {
            var creatures = _reefContext.Creatures.Where(x => x.Subcategory.Category.Id == category.Id);
            LoadIntoCreatures(creatures);

            return creatures;
        }

        public IEnumerable<Creature> GetCreaturesBySubcategory(Subcategory subcategory)
        {
            var creatures = _reefContext.Creatures.Where(x => x.Subcategory.Id == subcategory.Id);
            LoadIntoCreatures(creatures);
            
            return creatures;
        }

        public IEnumerable<Subcategory> GetSubcategories(Category category)
        {
            var subcategories = _reefContext.Subcategories.Where(x => x.CategoryId == category.Id);
            LoadIntoSubcategories(subcategories);

            return subcategories;
        }

        public Subcategory GetFirstSubcategory()
        {
            var subcategory = _reefContext.Subcategories.FirstOrDefault();
            LoadIntoSubcategory(subcategory);
            return subcategory;
        }

        public Category GetFirstCategory()
        {
            return _reefContext.Categories.FirstOrDefault();
        }

        public void SaveMedia(Media media)
        {
            _reefContext.Media.Update(media);
            _reefContext.SaveChangesAsync();
        }

        #region SubcategoryLoader 
        public void LoadIntoSubcategory(Subcategory subcategory)
        {
            _reefContext.Entry(subcategory)
                .Collection(x => x.Creatures)
                .Load();

            _reefContext.Entry(subcategory)
                .Reference(x => x.Category)
                .Load();
        }

        public void LoadIntoSubcategories(IEnumerable<Subcategory> subcategories)
        {
            foreach (var subcategory in subcategories)
            {
                LoadIntoSubcategory(subcategory);
            }
        }

        #endregion


        #region CreatureLoading

        public void LoadIntoCreature(Creature creature)
        {
            _reefContext.Entry(creature)
                .Collection(x => x.CreatureReferences)
                .Load();

            _reefContext.Entry(creature)
                .Collection(x => x.CreatureTags)
                .Load();

            _reefContext.Entry(creature)
                .Reference(x => x.Subcategory)
                .Load();

            _reefContext.Entry(creature.Subcategory)
                .Reference(x => x.Category)
                .Load();
        }

        public void LoadIntoCreatures(IEnumerable<Creature> creatures)
        {
            foreach (var creature in creatures)
            {
                LoadIntoCreature(creature);
            }
        }

        #endregion
    }
}