using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReefTankCore.Models.Base;
using ReefTankCore.Models.Enums;

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
            LoadIntoCategory(category);

            return category;
        }

        public IEnumerable<Category> GetCategories()
        {
            var categories = _reefContext.Categories.Include(x => x.Subcategories).ToList();
            LoadIntoCategories(categories);
            return categories;
        }

        public Subcategory GetSubcategory(Guid id)
        {
            var subcategory = _reefContext.Subcategories.Find(id);
            LoadIntoSubcategory(subcategory);
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
            _reefContext.SaveChanges();
        }
        
        public Category GetCategory(Guid id)
        {
            var category = _reefContext.Categories.Find(id);
            LoadIntoCategory(category);
            return category;
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

            return creature;
        }

        public async Task<Creature> GetCreatureAsync(Guid id)
        {
            var creature = await _reefContext.Creatures.FindAsync(id);

            LoadIntoCreature(creature);

            return creature;
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
            var category = _reefContext.Categories.FirstOrDefault();
            LoadIntoCategory(category);
            return category;
        }

        public void SaveMedia(Media media)
        {
            _reefContext.Media.Update(media);
            _reefContext.SaveChangesAsync();
        }

        public async Task SaveCreatureAsync(Creature creature)
        {
            _reefContext.Creatures.Update(creature);
            await _reefContext.SaveChangesAsync();
        }

        public Media GetImage(Guid id)
        {
            return _reefContext.Media.Find(id);
        }

        public IEnumerable<Tag> GetTags()
        {
            return _reefContext.Tags;
        }

        public IEnumerable<CreatureTag> GetCreatureTags(Creature creature)
        {
            var creatureTags = _reefContext.CreatureTags.Where(x => x.CreatureId == creature.Id);
            return creatureTags;
        }

        public void DeleteCreatureTag(CreatureTag tag)
        {
            _reefContext.CreatureTags.Remove(tag);
            _reefContext.SaveChanges();
        }

        public void SaveCreatureTag(CreatureTag creatureTag)
        {
            _reefContext.CreatureTags.Add(creatureTag);
            _reefContext.SaveChanges();
        }

        public void DeleteCreature(Creature creature)
        {
            _reefContext.Creatures.Remove(creature);
            _reefContext.SaveChanges();
        }

        public async Task DeleteCreatureAsync(Creature creature)
        {
            _reefContext.Creatures.Remove(creature);
            await _reefContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Creature>> GetCreaturesAsync()
        {
            var creatures = await _reefContext.Creatures.ToListAsync();
            return creatures;
        }

        public async Task SaveCategoryAsync(Category category)
        {
            _reefContext.Categories.Update(category);
            await _reefContext.SaveChangesAsync();
        }

        public void SaveSubcategory(Subcategory subcategory)
        {
            _reefContext.Subcategories.Add(subcategory);
            _reefContext.SaveChanges();
        }

        public void UpdateSubcategory(Subcategory subcategory)
        {
            _reefContext.Subcategories.Update(subcategory);
            _reefContext.SaveChanges();
        }

        #region SubcategoryLoader 

        /// <summary>
        /// Loads related entities into a Subcategory entity.
        /// </summary>
        /// <param name="subcategory"></param>
        public void LoadIntoSubcategory(Subcategory subcategory)
        {
            _reefContext.Entry(subcategory)
                .Collection(x => x.Creatures)
                .Load();

            _reefContext.Entry(subcategory)
                .Reference(x => x.Category)
                .Load();

            _reefContext.Entry(subcategory)
                .Reference(x => x.Media)
                .Load();
        }
        
        /// <summary>
        /// Loads related entities into each provided Subcategory entity.
        /// </summary>
        /// <param name="subcategories"></param>
        public void LoadIntoSubcategories(IEnumerable<Subcategory> subcategories)
        {
            foreach (var subcategory in subcategories)
            {
                LoadIntoSubcategory(subcategory);
            }
        }

        #endregion


        #region CreatureLoading

        /// <summary>
        /// Loads related entities into a Creature entity.
        /// </summary>
        /// <param name="creature"></param>
        public void LoadIntoCreature(Creature creature)
        {
            _reefContext.Entry(creature)
                .Collection(x => x.CreatureReferences)
                .Load();

            _reefContext.Entry(creature)
                .Collection(x => x.CreatureTags)
                .Load();

            _reefContext.Entry(creature)
                .Reference(x => x.Media)
                .Load();

            _reefContext.Entry(creature)
                .Reference(x => x.Subcategory)
                .Load();

            _reefContext.Entry(creature.Subcategory)
                .Reference(x => x.Category)
                .Load();
        }

        /// <summary>
        /// Loads related entities into each provided Creature entity.
        /// </summary>
        /// <param name="creatures"></param>
        public void LoadIntoCreatures(IEnumerable<Creature> creatures)
        {
            foreach (var creature in creatures)
            {
                LoadIntoCreature(creature);
            }
        }
        #endregion

        #region LoadCategories
        public void LoadIntoCategories(IList<Category> categories)
        {
            foreach (var cat in categories)
            {
                LoadIntoCategory(cat);
            }
        }

        public void LoadIntoCategory(Category category)
        {
            _reefContext.Entry(category)
                .Reference(x => x.Media)
                .Load();
        }

        #endregion
    }
}