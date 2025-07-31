using DAL;
using Entities;
using Exceptions;

namespace Service
{
        /*
      * Service classes are used here to implement additional business logic/validation
      * */
    public class UserService : IUserService
    {
        /*
       Use constructor Injection to inject all required dependencies.
       */
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository repository)
        {
            userRepository = repository;
        }
        //This method should be used to delete an existing user. 
        public bool DeleteUser(string userId)
        {
            bool isDeleted = userRepository.DeleteUser(userId);
            if (isDeleted)
            {
                return isDeleted;
            }
            else
            {
                throw new UserNotFoundException($"User with id: {userId} does not exist");
            }
        }

        //This method should be used to get a user by userId.
        public User GetUserById(string userId)
        {
            User userById = userRepository.GetUserById(userId);
            if (userById != null)
                return userById;
            else
                throw new UserNotFoundException($"User with id: {userId} does not exist");
        }

        //This method should be used to save a new user.
        public bool RegisterUser(User user)
        {
            bool isRegistered = userRepository.RegisterUser(user);
            if (isRegistered)
                return isRegistered;
            else
                throw new UserAlreadyExistException($"This userid: {user.UserId} already exists");
        }

        //This method should be used to update an existing user.
        public bool UpdateUser(string userId,User user)
        {
            bool IsUpdated = userRepository.UpdateUser(user);
            if (IsUpdated)
                return IsUpdated;
            else
                throw new UserNotFoundException($"User with id: {userId} does not exist");
        }

        //This method should be used to validate a user using userId and password.
        public bool ValidateUser(string userId, string password)
        {

            bool isValidUser = userRepository.ValidateUser(userId, password);
            return isValidUser;
        }
    }
}
