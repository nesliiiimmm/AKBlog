using AKBlog.Core.Model;
using AKBlog.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AKBlog.Core.Repositories
{
    public class CategoryRepository:Repository<Category>,ICategoryRepository
    {
        public CategoryRepository(AKBlogMSSQLDBContext context)
            : base(context)
        { }
    }
}
