using AKBlog.Core.Model;
using AKBlog.Core.Repositories;
using AKBlog.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AKBlog.Data.Repositories
{
    public class TagsRepository:Repository<Tags>, ITagsRepository
    {
        public TagsRepository(AKBlogMSSQLDBContext context)
          : base(context)
        { }
    }
}
