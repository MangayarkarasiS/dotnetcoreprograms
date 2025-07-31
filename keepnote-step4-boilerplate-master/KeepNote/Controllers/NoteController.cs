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
    public class NoteController : ControllerBase
    {
        /*
        * NoteService should  be injected through constructor injection. Please note that we should not create service
        * object using the new keyword
        */
        private readonly INoteService _noteService;
        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }
        [HttpPost]
        public ActionResult Post([FromBody] Note note)
        {
            try
            {
                Note note1 = _noteService.CreateNote(note);
                if (note1 != null)
                {
                    return CreatedAtAction("Post", note1);
                }
                else
                    return Conflict();

            }
            catch (CategoryNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ReminderNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpDelete("{noteId}")]
        public ActionResult Delete(int noteId)
        {
            try
            {
                bool isDeleted = _noteService.DeleteNote(noteId);
                if (isDeleted)
                {
                    return Ok(isDeleted);
                }
                else
                    return NotFound();


            }
            catch (NoteNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPut("{noteId}")]
        public ActionResult Update(int noteId, [FromBody] Note note)
        {
            try
            {
                bool isUpdated = _noteService.UpdateNote(noteId, note);
                if (isUpdated)
                {
                    return Ok(isUpdated);
                }
                else
                    return NotFound();


            }
            catch (NoteNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (CategoryNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ReminderNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        /*
         * Define a handler method which will create a specific note by reading the
         * Serialized object from request body and save the note details in a Note table
         * in the database.Handle ReminderNotFoundException and
         * CategoryNotFoundException as well. please note that the userID
         * should be taken as the createdBy for the note.This handler method should
         * return any one of the status messages basis on different situations: 1.
         * 201(CREATED) - If the note created successfully. 2. 409(CONFLICT) - If the
         * noteId conflicts with any existing user
         * 
         * This handler method should map to the URL "/api/note" using HTTP POST method
         */

        /*
         * Define a handler method which will delete a note from a database.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the note deleted successfully from
         * database. 2. 404(NOT FOUND) - If the note with specified noteId is not found.
         * 
         * This handler method should map to the URL "/api/note/{id}" using HTTP Delete
         * method" where "id" should be replaced by a valid noteId without {}
         */

        /*
         * Define a handler method which will update a specific note by reading the
         * Serialized object from request body and save the updated note details in a
         * note table in database handle ReminderNotFoundException,
         * NoteNotFoundException, CategoryNotFoundException as well. please note that
         * the userID should be taken as the createdBy for the note. This
         * handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the note updated successfully. 2.
         * 404(NOT FOUND) - If the note with specified noteId is not found.
         * This handler method should map to the URL "/api/note/{id}" using HTTP PUT method.
         */

        /*
         * Define a handler method which will get us the notes by a userId.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the note found successfully.
         * 
         * This handler method should map to the URL "/api/note/{userId}" using HTTP GET method
         */
    }
}
