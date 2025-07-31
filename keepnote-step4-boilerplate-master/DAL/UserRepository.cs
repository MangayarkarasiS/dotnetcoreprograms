using System;
using System.Linq;
using Entities;

namespace DAL
{
    //Repository class is used to implement all Data access operations
    public class UserRepository : IUserRepository
    {
        private KeepDbContext appDB;
        public UserRepository(KeepDbContext dbContext)
        {
            appDB = dbContext;
        }

        //This method should be used to delete an existing user. 
        public bool DeleteUser(string userId)
        {
            var _userId = appDB.Users.Find(userId);
            if (_userId != null)
            {
                appDB.Users.Remove(_userId);
                appDB.SaveChanges();
                return true;
            }
            else
                return false;

        }
        //This method should be used to get a user by userId.
        public User GetUserById(string userId)
        {
            User userbaseById = appDB.Users.FirstOrDefault(c => c.UserId == userId);
            return userbaseById;
        }
        //This method should be used to save a new user.
        public bool RegisterUser(User user)
        {
            appDB.Users.Add(user);
           int i= appDB.SaveChanges();
            if (i > 0)
                return true;
            else
                return false;

        }
        //This method should be used to update an existing user.
        public bool UpdateUser(User user)
        {
            var _user = appDB.Users.FirstOrDefault(s => s.UserId == user.UserId);
            if (_user != null)
            {
                appDB.Entry<User>(_user).CurrentValues.SetValues(user);
                appDB.SaveChanges();
                return true;
            }
            else
                return false;
        }
        //This method should be used to validate a user using userId and password.
        public bool ValidateUser(string userId, string password)
        {
            User userbaseById = appDB.Users.FirstOrDefault(c => c.UserId == userId && c.Password == password);
            if (userbaseById != null)
                return true;
            else
                return false;
        }
    }
}
