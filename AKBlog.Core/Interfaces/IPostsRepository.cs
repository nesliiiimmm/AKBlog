using AKBlog.Core.Helper;
using AKBlog.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace AKBlog.Core.Repositories
{
    public interface IPostsRepository : IRepository<Posts>
    {
        IEnumerable<Posts> GetPostsWithPaging(PageParameters ownerParameters);
        IEnumerable<Posts> GetPostsWithPagingandCategoryName(PageParameters ownerParameters,string Name);
    }
}
