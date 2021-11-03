using AKBlog.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace AKBlog.Core.Repositories
{
    public interface ITagsRepository:IRepository<Tags>
    {
        Task<IEnumerable<Tags>> GetAllWithTagsAsync();
        Task<Tags> GetWithTagsByIdAsync(int id);
        Task AddTagsAsync(Tags entity);
        Task AddRangeTagsAsync(IEnumerable<Tags> entities);
        void RemoveTags(Tags entity);
        void RemoveTagsRange(IEnumerable<Tags> entities);
    }
}
