using AKBlog.Core.Model;
using AKBlog.Core.Repositories;
using AKBlog.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKBlog.Data.Repositories
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        AKBlogMSSQLDBContext ctx;
        public UserRepository(AKBlogMSSQLDBContext context)
          : base(context)
        { }

        public List<Posts> GetUsersWithPosts(int userId)
        {
            List<Posts> data =  ctx.Posts.Where(x => x.UserId == userId).ToList();

            return data;
        }
    }
}
