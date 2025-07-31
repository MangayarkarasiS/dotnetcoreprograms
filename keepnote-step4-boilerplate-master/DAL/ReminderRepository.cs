using System;
using System.Collections.Generic;
using System.Linq;
using Entities;

namespace DAL
{
    //Repository class is used to implement all Data access operations
    public class ReminderRepository : IReminderRepository
    {
        private KeepDbContext appDB;
        public ReminderRepository(KeepDbContext dbContext)
        {
            appDB = dbContext;
        }
        //This method should be used to save a new reminder.
        public Reminder CreateReminder(Reminder reminder)
        {
            appDB.Reminders.Add(reminder);
            appDB.SaveChanges();
            return reminder;
        }
        //This method should be used to delete an existing reminder.
        public bool DeletReminder(int reminderId)
        {
            var _reminderId = appDB.Reminders.Find(reminderId);
            if (_reminderId != null)
            {
                appDB.Reminders.Remove(_reminderId);
                appDB.SaveChanges();
                return true;
            }
            else
                return false;

        }
        //This method should be used to get all reminder by userId.
        public List<Reminder> GetAllRemindersByUserId(string userId)
        {
            return appDB.Reminders.Where(c => c.CreatedBy == userId).ToList();
        }
        //This method should be used to get a reminder by reminderId.
        public Reminder GetReminderById(int reminderId)
        {
            Reminder reminderbaseById = appDB.Reminders.FirstOrDefault(c => c.ReminderId == reminderId);
            return reminderbaseById;
        }
        // This method should be used to update a existing reminder.
        public bool UpdateReminder(Reminder reminder)
        {
            var _reminder = appDB.Reminders.FirstOrDefault(s => s.ReminderId == reminder.ReminderId);
            if (_reminder != null)
            {
                appDB.Entry<Reminder>(_reminder).CurrentValues.SetValues(reminder);
                appDB.SaveChanges();
                return true;
            }
            else
                return false;

        }
    }
}
