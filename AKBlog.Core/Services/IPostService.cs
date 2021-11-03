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
        Task<IEnumerable<Posts>> GetAllWitCategoryhWithCategoryId(int CategoryId);
        Task<IEnumerable<Posts>> GetAllWitUserhWithUserId(int UserId);
        Task<IEnumerable<Posts>> GetAllWitTaghWithTagId(int TagId);
        Task<Posts> GetPostById(int id);
        Task<Posts> CreatePost(Posts newPost);
        Task UpdatePost(Posts PostToBeUpdated, Posts Post);
        Task DeletePost(Posts Post);
    }
}
