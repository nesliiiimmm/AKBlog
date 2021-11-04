using AKBlog.Core.Model;
using AKBlog.Core.Repositories;
using AKBlog.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AKBlog.Data.Repositories
{
    public class CommentsRepository:Repository<Comments>,ICommentsRepository
    {
        public CommentsRepository(AKBlogMSSQLDBContext context)
            : base(context)
        { }
    }
}
