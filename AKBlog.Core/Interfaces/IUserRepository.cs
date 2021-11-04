using AKBlog.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace AKBlog.Core.Repositories
{
    public interface IUserRepository:IRepository<User>
    {
        List<Posts> GetUsersWithPosts(int userId);
    }
}
