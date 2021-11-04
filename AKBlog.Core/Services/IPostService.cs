using AKBlog.Core.Model;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace AKBlog.Core.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Posts>> GetAllPosts();
        Task<IEnumerable<Posts>> GetAllCategoryWithCategoryId(int CategoryId);
        Task<IEnumerable<Posts>> GetAllWithUserWithUserId(int UserId);
        Task<IEnumerable<Posts>> GetAllWithTagWithTagId(int TagId);
        Task<Posts> GetPostById(int id);
        Task<Posts> CreatePost(Posts newPost);
        Task UpdatePost(Posts Post);
        Task DeletePost(Posts Post);
    }
}
