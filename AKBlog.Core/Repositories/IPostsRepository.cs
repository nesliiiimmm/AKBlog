using AKBlog.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace AKBlog.Core.Repositories
{
    public interface IPostsRepository:IRepository<Posts>
    {
        Task<IEnumerable<Posts>> GetAllWithPostsAsync();
        Task<Comments> GetWithCommentsByIdAsync(int id);
        Task<IEnumerable<Posts>> GetAllWitCategoryhWithCategoryIdAsync(int CategoryId);
        Task<IEnumerable<Posts>> GetAllWitUserhWithUserIdAsync(int UserId);
        Task<IEnumerable<Posts>> GetAllWitTaghWithTagIdAsync(int TagId);
        Task AddPostsAsync(Posts entity);
        Task AddRangePostsAsync(IEnumerable<Posts> entities);
        void RemovePosts(Posts entity);
        void RemovePostsRange(IEnumerable<Posts> entities);

    }
}
