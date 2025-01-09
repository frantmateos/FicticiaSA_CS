using System.Collections.Generic;
using users.Models;
using users.Repo;

namespace users.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _repository;

        public UserService(IUserRepo repository)
        {
            _repository = repository;
        }


        public List<User> GetAll()
        {
            return _repository.GetAllUsers().ToList();
        }

        public User GetById(int id)
        {
            return _repository.GetUserById(id);
        }

        public bool Save(User user)
        {
            try
            {
                _repository.InsertUser(user); 
                return true; 
            }
            catch
            {
                return false; 
            }
        }

        public void Update(int id, User user)
        {
            var existingUser = _repository.GetUserById(id);
            if (existingUser != null)
            {
                existingUser.Nombre = user.Nombre;
                existingUser.Password = user.Password;
                _repository.UpdateUser(existingUser);
            }
        }

    }
}
