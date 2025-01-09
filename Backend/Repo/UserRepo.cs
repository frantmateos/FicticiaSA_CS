using System.Collections.Generic;
using System.Linq;
using users.Models;
using users.Repo;

namespace users.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly userContext _context; 

        public UserRepo(userContext context)
        {
            _context = context;
        }

        public bool UserExists(string nombre)
        {
            return _context.Users.Any(u => u.Nombre == nombre);
        }

        public void InsertUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            var existingUser = _context.Users.Find(user.Id);
            if (existingUser != null)
            {
                existingUser.Nombre = user.Nombre;
                existingUser.Password = user.Password;
                // Actualiza otras propiedades según sea necesario...
                _context.Users.Update(existingUser);
                _context.SaveChanges();
            }
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

       
    }
}
