using Entities;
using Exceptions;
using KeepNote.Aspect;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;

namespace KeepNote.Controllers
{
    /*
     * As in this assignment, we are working with creating RESTful web service, hence annotate
     * the class with [ApiController] annotation and define the controller level route as per REST Api standard.
     */
    [ServiceFilter(typeof(LoggingAspect ))]
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        /*
         * UserService should  be injected through constructor injection. Please note that we should not create service
         * object using the new keyword
        */
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
     
        public IActionResult RegisterUser([FromBody] User user)
        {
            try
            {
                bool isCreated = _userService.RegisterUser(user);
                if (isCreated)
                {
                    return CreatedAtAction("Post", user);
                }
                else
                    return Conflict(new { message = $"An existing record with the id '{user.UserId }' was already found." });

            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }
        [HttpDelete("{userId}")]
        public ActionResult Delete(string userId)
        {
            try
            {
                bool isDeleted = _userService.DeleteUser(userId);
                if (isDeleted)
                {
                    return Ok(isDeleted);
                }
                else
                    return NotFound();


            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                User user = _userService.GetUserById(id);

                if (user != null)
                {
                    return Ok(user);
                }
                else
                    return NotFound();


            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{userId}")]

        public ActionResult Update(string userId, [FromBody] User user)
        {
            try
            {
                bool isUpdated = _userService.UpdateUser(userId, user);
                if (isUpdated)
                {
                    return Ok(isUpdated);
                }
                else
                    return NotFound();


            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult Authenticate(string id, string password)
        {
            bool isValidUser = _userService.ValidateUser(id, password);
            if (isValidUser)
                return Ok(isValidUser);
            else
                return NotFound($"User with id: {id} does not exist");
        }
        /*
	     * Define a handler method which will create a specific user by reading the
	     * Serialized object from request body and save the user details in a User table
	     * in the database. This handler method should return any one of the status
	     * messages basis on different situations: 1. 201(CREATED) - If the user created
	     * successfully. 2. 409(CONFLICT) - If the userId conflicts with any existing
	     * user
	     * 
	     * 
	     * This handler method should map to the URL "/api/user/register" using HTTP POST
	     * method
	     */

        /*
         * Define a handler method which will login a specific user by reading the
         * Serialized object from request body and validate the userId and Password
         * from User table in the database. This handler method should return any one of 
         * the status messages basis on different situations: 
         * 1. 200(OK) - If the user successfully logged in. 
         * 2. 404(NOTFOUND) -If the user with specified userId is not found.
         * 
         * This handler method should map to the URL "/api/user/login" using HTTP POST
         * method
         */

        /*
         * Define a handler method which will update a specific user by reading the
         * Serialized object from request body and save the updated user details in a
         * user table in database handle exception as well. This handler method should
         * return any one of the status messages basis on different situations: 1.
         * 200(OK) - If the user updated successfully. 2. 404(NOT FOUND) - If the user
         * with specified userId is not found. 
         * 
         * This handler method should map to the URL "/api/user/{id}" using HTTP PUT method.
         */

        /*
         * Define a handler method which will delete a user from a database.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the user deleted successfully from
         * database. 2. 404(NOT FOUND) - If the user with specified userId is not found.
         * 
         * This handler method should map to the URL "/api/user/{id}" using HTTP Delete
         * method" where "id" should be replaced by a valid userId without {}
         */

        /*
         * Define a handler method which will show details of a specific user handle
         * UserNotFoundException as well. This handler method should return any one of
         * the status messages basis on different situations: 1. 200(OK) - If the user
         * found successfully. 2. 404(NOT FOUND) - If the user with specified
         * userId is not found. This handler method should map to the URL "/api/user/{userId}"
         * using HTTP GET method where "id" should be replaced by a valid userId without
         * {}
         */
    }
}
