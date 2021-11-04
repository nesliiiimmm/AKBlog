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
        public UserRepository(AKBlogMSSQLDBContext context)
          : base(context)
        { }

        public IEnumerable<Posts> GetUsersWithPosts(int userId)
        {
            IEnumerable<Posts> data = AKBlogMSSQLDBContext.Posts.Where(x => x.UserId == userId).ToList();

            return data;
        }
        private AKBlogMSSQLDBContext AKBlogMSSQLDBContext
        {
            get { return Context as AKBlogMSSQLDBContext; }
        }
    }
}
