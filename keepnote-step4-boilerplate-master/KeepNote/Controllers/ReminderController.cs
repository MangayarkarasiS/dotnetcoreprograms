using Entities;
using Exceptions;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;

namespace KeepNote.Controllers
{
    /*
    * As in this assignment, we are working with creating RESTful web service, hence annotate
    * the class with [ApiController] annotation and define the controller level route as per REST Api standard.
    */
    [Route("api/[controller]")]
    [ApiController]
    public class ReminderController : ControllerBase
    {
        /*
       * ReminderService should  be injected through constructor injection. Please note that we should not create service
       * object using the new keyword
       */
        private readonly IReminderService _reminderService;
        public ReminderController(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }
        [HttpPost()]
        public ActionResult Post([FromBody] Reminder reminder)
        {
            try
            {
                Reminder reminder1 = _reminderService.CreateReminder(reminder);
                if (reminder1 != null)
                {
                    return CreatedAtAction("Post", reminder1);
                }
                else
                    return Conflict();

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpDelete("{reminderId}")]
        public ActionResult Delete(int reminderId)
        {
            try
            {
                bool isDeleted = _reminderService.DeletReminder(reminderId);
                if (isDeleted)
                {
                    return Ok(isDeleted);
                }
                else
                    return NotFound();


            }
            catch (ReminderNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet("{id:int}")]
        public ActionResult<Reminder> GetById(int id)
        {
            try
            {
                Reminder reminder = _reminderService.GetReminderById(id);

                if (reminder != null)
                {
                    return Ok(reminder);
                }
                else
                    return NotFound();


            }
            catch (ReminderNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {

                return BadRequest();
            }


        }
        [HttpPut("{reminderId}")]

        public ActionResult Update(int reminderId, [FromBody] Reminder reminder)
        {
            try
            {
                bool isUpdated = _reminderService.UpdateReminder(reminderId, reminder);
                if (isUpdated)
                {
                    return Ok(isUpdated);
                }
                else
                    return NotFound();


            }
            catch (ReminderNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        /*
	     * Define a handler method which will create a reminder by reading the
	     * Serialized reminder object from request body and save the reminder in
	     * reminder table in database. Please note that the reminderId has to be unique
	     * and userID should be taken as the reminderCreatedBy for the
	     * reminder. This handler method should return any one of the status messages
	     * basis on different situations: 1. 201(CREATED - In case of successful
	     * creation of the reminder 2. 409(CONFLICT) - In case of duplicate reminder ID
	     * 
	     * This handler method should map to the URL "/api/reminder" using HTTP POST
	     * method".
	     */

        /*
         * Define a handler method which will delete a reminder from a database.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the reminder deleted successfully from
         * database. 2. 404(NOT FOUND) - If the reminder with specified reminderId is
         * not found. 
         * 
         * This handler method should map to the URL "/api/reminder/{id}" using HTTP Delete
         * method" where "id" should be replaced by a valid reminderId without {}
         */

        /*
         * Define a handler method which will update a specific reminder by reading the
         * Serialized object from request body and save the updated reminder details in
         * a reminder table in database handle ReminderNotFoundException as well.
         * This handler method should return any one of the status
         * messages basis on different situations: 1. 200(OK) - If the reminder updated
         * successfully. 2. 404(NOT FOUND) - If the reminder with specified reminderId
         * is not found. 
         * 
         * This handler method should map to the URL "/api/reminder/{id}" using HTTP PUT
         * method.
         */

        /*
         * Define a handler method which will get us the reminders by a userId.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the reminder found successfully.
         * 
         * This handler method should map to the URL "/api/reminder/{userId}" using HTTP GET method
         */

        /*
         * Define a handler method which will show details of a specific reminder handle
         * ReminderNotFoundException as well. This handler method should return any one
         * of the status messages basis on different situations: 1. 200(OK) - If the
         * reminder found successfully. 2. 404(NOT FOUND) - If the reminder
         * with specified reminderId is not found. This handler method should map to the
         * URL "/api/reminder/{id}" using HTTP GET method where "id" should be replaced by a
         * valid reminderId without {}
         */
    }
}
