using Entities;
using Exceptions;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;

namespace KeepNote.Controllers
{
    /*
 * As in this assignment, we are working with creating RESTful web service, hence annotate
 * the class with [ApiController] annotation and define the controller level route as per REST Api standard.
 */
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        /*
      * CategoryService should  be injected through constructor injection. Please note that we should not create service
      * object using the new keyword
      */
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        public ActionResult Post([FromBody] Category category)
        {
            try
            {
                Category category1 = _categoryService.CreateCategory(category);
                if (category1 != null)
                {
                    return CreatedAtAction("Post", category1);
                }
                else
                    return Conflict();

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpDelete("{categoryId}")]
        public ActionResult Delete(int categoryId)
        {
            try
            {
                bool isDeleted = _categoryService.DeleteCategory(categoryId);
                if (isDeleted)
                {
                    return Ok(isDeleted);
                }
                else
                    return NotFound();


            }
            catch (CategoryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet("{id:int}")]
        public ActionResult<Category> GetById(int id)
        {
            try
            {
                Category category = _categoryService.GetCategoryById(id);

                if (category != null)
                {
                    return Ok(category);
                }
                else
                    return NotFound();


            }
            catch (CategoryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {

                return BadRequest();
            }


        }
        [HttpPut("{categoryId}")]

        public ActionResult Update(int categoryId, [FromBody] Category category)
        {
            try
            {
                if (categoryId != category.CategoryId)
                {
                    return BadRequest();
                }
                bool isUpdated = _categoryService.UpdateCategory(categoryId, category);
                if (isUpdated)
                {
                    return Ok(isUpdated);
                }
                else
                    return NotFound();


            }
            catch (CategoryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet("{userId}")]
        public ActionResult<List<Category>> ByUserId(string userId)
        {
            try
            {
                List<Category> category = _categoryService.GetAllCategoriesByUserId(userId);

                if (category.Count > 0)
                {
                    return Ok(category);
                }
                else
                    return NotFound();


            }
            catch (CategoryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {

                return BadRequest();
            }


        }

        /*
         * Define a handler method which will create a category by reading the
         * Serialized category object from request body and save the category in
         * category table in database. Please note that the careatorId has to be unique
         * and the userID should be taken as the categoryCreatedBy for the
         * category. This handler method should return any one of the status messages
         * basis on different situations: 1. 201(CREATED - In case of successful
         * creation of the category 2. 409(CONFLICT) - In case of duplicate categoryId
         * 
         *  * This handler method should map to the URL "/api/category" using HTTP POST method
        /*
         
          
         * Define a handler method which will delete a category from a database.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the category deleted successfully from
         * database. 2. 404(NOT FOUND) - If the category with specified categoryId is
         * not found. 
         * 
         * This handler method should map to the URL "/api/category/{id}" using HTTP Delete
         * method" where "id" should be replaced by a valid categoryId without {}
         */

        /*
         * Define a handler method which will update a specific category by reading the
         * Serialized object from request body and save the updated category details in
         * a category table in database handle CategoryNotFoundException as well. please
         * note that the loggedIn userID should be taken as the categoryCreatedBy for
         * the category. This handler method should return any one of the status
         * messages basis on different situations: 1. 200(OK) - If the category updated
         * successfully. 2. 404(NOT FOUND) - If the category with specified categoryId
         * is not found. 
         * 
         * This handler method should map to the URL "/api/category/{id}" using HTTP PUT
         * method.
         */

        /*
         * Define a handler method which will get us the category by a userId.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the category found successfully. 
         * 
         * This handler method should map to the URL "/api/category/{userId}" using HTTP GET method
         */
    }
}
