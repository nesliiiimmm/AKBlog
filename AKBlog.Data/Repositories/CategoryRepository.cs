using AKBlog.Core.Helper;
using AKBlog.Core.Model;
using AKBlog.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AKBlog.Core.Repositories
{
    public class CategoryRepository:Repository<Category>,ICategoryRepository
    {
        public CategoryRepository(AKBlogMSSQLDBContext context)
            : base(context)
        { }
        private AKBlogMSSQLDBContext AKBlogMSSQLDBContext
        {
            get { return Context as AKBlogMSSQLDBContext; }
        }
       
    }
}
