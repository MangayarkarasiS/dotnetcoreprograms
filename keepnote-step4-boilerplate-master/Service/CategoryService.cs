using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Entities;
using Exceptions;

namespace Service
{
    /*
    * Service classes are used here to implement additional business logic/validation
    * */
    public class CategoryService : ICategoryService
    {
        /*
        Use constructor Injection to inject all required dependencies.
            */
        private readonly ICategoryRepository repository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            repository = categoryRepository;
        }

        /*
	    * This method should be used to save a new category.
	    */
        public Category CreateCategory(Category category)
        {
            return repository.CreateCategory(category);
        }

        /* This method should be used to delete an existing category. */
        public bool DeleteCategory(int categoryId)
        {

            bool isDeleted = repository.DeleteCategory(categoryId);
            if (!isDeleted)
                throw new CategoryNotFoundException($"Category with id: {categoryId} does not exist");
            else
                return true;
        }

        /*
	     * This method should be used to get all category by userId.
	     */
        public List<Category> GetAllCategoriesByUserId(string userId)
        {
            return repository.GetAllCategoriesByUserId(userId);
        }

        /*
	     * This method should be used to get a category by categoryId.
	     */
        public Category GetCategoryById(int categoryId)
        {
            Category category = repository.GetCategoryById(categoryId);
            if (category == null)
                throw new CategoryNotFoundException($"Category with id: {categoryId} does not exist");
            else
                return category;
        }

        /*
	    * This method should be used to update a existing category.
	    */
        public bool UpdateCategory(int categoryId, Category category)
        {
            bool isUpdated = repository.UpdateCategory(category);
            if (!isUpdated)
            {
                throw new CategoryNotFoundException($"Category with id: {categoryId} does not exist");
            }
            else
                return isUpdated;
        }
    }
}
