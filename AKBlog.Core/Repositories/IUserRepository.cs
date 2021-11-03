using AKBlog.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace AKBlog.Core.Repositories
{
    public interface IUserRepository:IRepository<User>
    {
        Task<IEnumerable<User>> GetAllWithUserAsync();
        Task<User> GetWithUserByIdAsync(int id);
        Task AddUserAsync(User entity);
        Task AddUserRangeAsync(IEnumerable<User> entities);
        void RemoveUser(User entity);
        void RemoveUserRange(IEnumerable<User> entities);
    }
}
