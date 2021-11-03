using AKBlog.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AKBlog.Core.Repositories
{
    public interface ICategoryRepository:IRepository<Category>
    {
        Task<IEnumerable<Category>> GetAllWithCategoryAsync();
        Task<Category> GetWithCategoryByIdAsync(int id);
        Task AddCategoryAsync(Category entity);
        Task AddRangeCategoryAsync(IEnumerable<Category> entities);
        void RemoveCategory(Category entity);
        void RemoveCategoryRange(IEnumerable<Category> entities);
    }
}
