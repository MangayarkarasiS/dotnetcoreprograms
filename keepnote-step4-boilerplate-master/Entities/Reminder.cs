﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Newtonsoft.Json;

namespace Entities
{
    // The class "Reminder" will be acting as the data model for the Reminder Table in the database. 
    public class Reminder
    {
        /*
	     * This class should have eight fields
	     * (reminderId,reminderName,reminderDescription,reminderType,
	     * reminderCreatedBy,reminderCreationDate,notes, user). Out of these eight fields, the
	     * field reminderId should be primary key and auto-generated. The value of
	     * reminderCreationDate should not be accepted from the user but should be
	     * always initialized with the system date. annotate notes and user field with [JsonIgnore]
	     */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReminderId { get; set; }
        public string ReminderName { get; set; }
        public string ReminderDescription { get; set; }
        public string ReminderType { get; set; }
        public string ReminderCreatedBy { get; set; }
        public DateTime ReminderCreationDate { get { return DateTime.Now.Date; } }
        public DateTime CreatedAt { get; set; }
        public Note Notes { get; set; }
        public string CreatedBy { get; set; }
    }
}
