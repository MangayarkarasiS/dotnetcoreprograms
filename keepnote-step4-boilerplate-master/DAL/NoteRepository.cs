using System.Collections.Generic;
using System.Linq;
using Entities;

namespace DAL
{
    //Repository class is used to implement all Data access operations
    public class NoteRepository : INoteRepository
    {
        private readonly KeepDbContext appDB;
        public NoteRepository(KeepDbContext dbContext)
        {
            appDB = dbContext;
        }

        // This method should be used to save a new note.
        public Note CreateNote(Note note)
        {
            appDB.Notes.Add(note);
            appDB.SaveChanges();
            return note;
        }

        /* This method should be used to delete an existing note. */
        public bool DeleteNote(int noteId)
        {
            var _noteId = appDB.Notes.Find(noteId);
            if (_noteId != null)
            {
                appDB.Notes.Remove(_noteId);
                appDB.SaveChanges();
                return true;
            }
            else
                return false;
        }

        //* This method should be used to get all note by userId.
        public List<Note> GetAllNotesByUserId(string userId)
        {
            return appDB.Notes.Where(c => c.CreatedBy == userId).ToList();
        }
        //This method should be used to get a note by noteId.
        public Note GetNoteByNoteId(int noteId)
        {
            Note notebaseById = appDB.Notes.FirstOrDefault(c => c.NoteId == noteId);
            return notebaseById;
        }
        //This method should be used to update a existing note.
        public bool UpdateNote(Note note)
        {
            var _note = appDB.Notes.FirstOrDefault(s => s.NoteId == note.NoteId);
            if (_note != null)
            {
                appDB.Entry<Note>(_note).CurrentValues.SetValues(note);
                appDB.SaveChanges();
                return true;
            }
            else
                return false;

        }
    }
}
