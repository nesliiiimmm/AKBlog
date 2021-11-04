using AKBlog.Core.Model;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace AKBlog.Core.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> CreateUser(User newUser);
        Task UpdateUser(User User);
        Task DeleteUser(User User);
    }
}
