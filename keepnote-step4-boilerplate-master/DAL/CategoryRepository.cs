using System;
using System.Collections.Generic;
using System.Linq;
using Entities;

namespace DAL
{
    //Repository class is used to implement all Data access operations
    public class CategoryRepository : ICategoryRepository
    {
        public KeepDbContext appDB;
        public CategoryRepository(KeepDbContext dbContext)
        {
            appDB = dbContext;
        }
        /*
	    * This method should be used to save a new category.
	    */
        public Category CreateCategory(Category category)
        {
            appDB.Categories.Add(category);
            appDB.SaveChanges();
            return category;
        }
        /* This method should be used to delete an existing category. */
        public bool DeleteCategory(int categoryId)
        {

            var _categoryId = appDB.Categories.Find(categoryId);
            if (_categoryId != null)
            {
                appDB.Categories.Remove(_categoryId);
                appDB.SaveChanges();
                return true;
            }
            else
                return false;

        }
        //* This method should be used to get all category by userId.
        public List<Category> GetAllCategoriesByUserId(string userId)
        {
            return appDB.Categories.Where(c => c.CreatedBy == userId).ToList();
        }

        /*
	     * This method should be used to get a category by categoryId.
	     */
        public Category GetCategoryById(int categoryId)
        {
            Category categorybaseById = appDB.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
            return categorybaseById;
        }

	    // This method should be used to update an existing category.
        public bool UpdateCategory(Category category)
        {

            var _category = appDB.Categories.FirstOrDefault(s => s.CategoryId == category.CategoryId);
            if (_category != null)
            {
                appDB.Entry<Category>(_category).CurrentValues.SetValues(category);
                appDB.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
