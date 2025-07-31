using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Newtonsoft.Json;

namespace Entities
{
    //The class "Note" will be acting as the data model for the Note Table in the database. 
    public class Note
    {
        /*
	 * This class should have nine fields
	 * (noteId,noteTitle,noteContent,noteStatus,createdAt,
	 * category,reminder,user, createdBy). Out of these nine fields, the field noteId
	 * should be primary key and auto-generated. The value of createdAt should not be
	 * accepted from the user but should be always initialized with the system date.
	 * annotate category, reminder and user field with [JsonIgnore].
	 */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteId { get; set; }
        public string NoteTitle { get; set; }
        public string NoteContent { get; set; }
        public string NoteStatus { get; set; }
        public DateTime CreatedAt { get { return DateTime.Now.Date; } }
        public string CreatedBy { get; set; }

        public int CategoryId { get; set; }
        public int ReminderId { get; set; }
        public string UserId { get; set; }
        [JsonIgnore]
        public virtual Reminder Reminder { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
