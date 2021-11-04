using AKBlog.Core.Model;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using AKBlog.Core.Helper;

namespace AKBlog.Core.Services
{
    public interface IPostService
    {
        IEnumerable<Posts> GetAllPosts();
        IEnumerable<Posts> GetAllCategoryWithCategoryId(int CategoryId);
        IEnumerable<Posts> GetAllWithUserWithUserId(int UserId);
        IEnumerable<Posts> GetAllWithTagWithTagId(int TagId);
        Task<Posts> GetPostById(int id);
        Task<Posts> CreatePost(Posts newPost);
        Task UpdatePost(Posts Post);
        Task DeletePost(Posts Post);
        List<Posts> GetBestRead5();
        IEnumerable<Posts> GetPostsWithPaging(PageParameters ownerParameters);
    }
}
