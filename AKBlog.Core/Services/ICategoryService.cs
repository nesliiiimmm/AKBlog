using AKBlog.Core.Model;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using AKBlog.Core.Helper;

namespace AKBlog.Core.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllWithCategory();
        Task<Category> GetCategoryById(int id);
        Task<Category> CreateCategory(Category newCategory);
        Task UpdateCategory(Category category);
        Task DeleteCategory(Category category);
        IEnumerable<Category> GetCategoryWithPaging(PageParameters ownerParameters);

    }
}
