using System.Collections.Generic;
using DAL;
using Entities;
using Exceptions;

namespace Service
{
    /*
   * Service classes are used here to implement additional business logic/validation
   * */
    public class NoteService : INoteService
    {
        /*
         Use constructor Injection to inject all required dependencies.
             */
        private readonly ICategoryRepository categoryRepository;
        private readonly INoteRepository noteRepository;
        private readonly IReminderRepository reminderRepository;
        public NoteService(INoteRepository repository, ICategoryRepository category, IReminderRepository reminder)
        {
            noteRepository = repository;
            categoryRepository = category;
            reminderRepository = reminder;
        }

        /*
	     * This method should be used to save a new note.
	     */
        public Note CreateNote(Note note)
        {
            Category category = categoryRepository.GetCategoryById(note.CategoryId);
            if (category == null)
                throw new CategoryNotFoundException($"Category with id: {note.CategoryId} does not exist");

            Reminder reminderById = reminderRepository.GetReminderById(note.ReminderId);
            if (reminderById == null)
            {
                throw new ReminderNotFoundException($"Reminder with id: {note.ReminderId} does not exist");
            }
            return noteRepository.CreateNote(note);
        }
        /* This method should be used to delete an existing note. */
        public bool DeleteNote(int noteId)
        {
            return noteRepository.DeleteNote(noteId);
        }

        /*
	     * This method should be used to get all note by userId.
	     */
        public List<Note> GetAllNotesByUserId(string userId)
        {
            return noteRepository.GetAllNotesByUserId(userId);
        }

        //This method should be used to get a note by noteId.
        public Note GetNoteByNoteId(int noteId)
        {
            Note noteById = noteRepository.GetNoteByNoteId(noteId);
            if (noteById != null)
            {
                return noteById;
            }
            else
                throw new NoteNotFoundException($"Note with id: { noteId } does not exist");
        }
        //This method should be used to update a existing note.
        public bool UpdateNote(int noteId,Note note)
        {
            Category category = categoryRepository.GetCategoryById(note.CategoryId);
            if (category == null)
                throw new CategoryNotFoundException($"Category with id: {note.CategoryId} does not exist");

            Reminder reminderById = reminderRepository.GetReminderById(note.ReminderId);
            if (reminderById == null)
            {
                throw new ReminderNotFoundException($"Reminder with id: {note.ReminderId} does not exist");
            }
            bool isUpdated = noteRepository.UpdateNote(note);
            if (isUpdated)
                return isUpdated;
            else
                throw new NoteNotFoundException($"Note with id: {noteId} does not exist");
        }
    }
}
