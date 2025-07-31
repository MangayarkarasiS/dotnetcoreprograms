using System.Collections.Generic;
using DAL;
using Entities;
using Exceptions;

namespace Service
{
    /*
   * Service classes are used here to implement additional business logic/validation
   * */
    public class ReminderService : IReminderService
    {
        /*
        Use constructor Injection to inject all required dependencies.
        */
        private readonly IReminderRepository repository;
        public ReminderService(IReminderRepository reminderRepository)
        {
            repository = reminderRepository;
        }

        //This method should be used to save a new reminder.
        public Reminder CreateReminder(Reminder reminder)
        {
            return repository.CreateReminder(reminder);
        }

        //This method should be used to delete an existing reminder.
        public bool DeletReminder(int reminderId)
        {
            bool isDeleted = repository.DeletReminder(reminderId);
            if (isDeleted)
            {
                return isDeleted;
            }
            else
            {
                throw new ReminderNotFoundException($"Reminder with id: {reminderId} does not exist");
            }

        }

        //This method should be used to get all reminder by userId.
        public List<Reminder> GetAllRemindersByUserId(string userId)
        {
            return repository.GetAllRemindersByUserId(userId);
        }
        //This method should be used to get a reminder by reminderId.
        public Reminder GetReminderById(int reminderId)
        {
            Reminder reminderById = repository.GetReminderById(reminderId);
            if (reminderById != null)
            {
                return reminderById;
            }
            else
                throw new ReminderNotFoundException($"Reminder with id: {reminderId} does not exist");
        }

        // This method should be used to update a existing reminder.
        public bool UpdateReminder(int reminderId,Reminder reminder)
        {
            bool isUpdated = repository.UpdateReminder(reminder);
            if (!isUpdated)
            {
                throw new ReminderNotFoundException($"Reminder with id: {reminderId} does not exist");
            }
            else
                return isUpdated;
        }
    }
}
