using AKBlog.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace AKBlog.Core.Repositories
{
    public interface ICommentsRepository:IRepository<Comments>
    {
        Task<IEnumerable<Comments>> GetAllWithCommentsAsync();
        Task<Comments> GetWithCommentsByIdAsync(int id);
        Task<IEnumerable<Comments>> GetAllWithPostWithPostIdAsync(int PostId);
        Task AddCommentsAsync(Comments entity);
        Task AddRangeCommentsAsync(IEnumerable<Comments> entities);
        void RemoveComments(Comments entity);
        void RemoveCommentsRange(IEnumerable<Comments> entities);
    }
}
