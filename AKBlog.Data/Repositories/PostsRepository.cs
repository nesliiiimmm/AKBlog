using AKBlog.Core.Helper;
using AKBlog.Core.Model;
using AKBlog.Core.Repositories;
using AKBlog.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AKBlog.Data.Repositories
{
    public class PostsRepository: Repository<Posts>, IPostsRepository
    {
        protected readonly DbContext Context;
        public PostsRepository(AKBlogMSSQLDBContext context)
            : base(context)
        { }

        private AKBlogMSSQLDBContext AKBlogMSSQLDBContext
        {
            get { return Context as AKBlogMSSQLDBContext; }
        }

        public IEnumerable<Posts> GetPostsWithPaging(PageParameters ownerParameters)
        {
            
            return Context.Set<Posts>().Where(x=>x.IsActive == true)
                .OrderBy(on => on.ID)
                .Skip((ownerParameters.PageNumber - 1) * ownerParameters.PageSize)
                .Take(ownerParameters.PageSize)
                .ToList();
        }
    }
}
