#nullable disable
using System.Collections.Generic;
using users.Models;

namespace users.Repo
{
    public interface IUserRepo
    {
        bool UserExists(string nombre);

        void InsertUser(User user);

        void UpdateUser(User user);

        User GetUserById(int id);
        
        IEnumerable<User> GetAllUsers();

    }
}
