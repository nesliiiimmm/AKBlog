using AKBlog.Core;
using AKBlog.Core.Model;
using AKBlog.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AKBlog.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Category> CreateCategory(Category newCategory)
        {
            await _unitOfWork.Categories.AddAsync(newCategory);
            await _unitOfWork.CommitAsync();
            return newCategory;
        }

        public async Task DeleteCategory(Category category)
        {
            category.IsActive = false;
            await _unitOfWork.CommitAsync();
        }

        public  IEnumerable<Category> GetAllWithCategory()//Test
        {
            return _unitOfWork.Categories.Where(x => x.IsActive == true);
        }

        public  Task<Category> GetCategoryById(int id)//burda IsActive kısımları kontrol etmek gerekiyor 
        {
            return  _unitOfWork.Categories.FirstOrDefaultAsync(x => x.ID == id && x.IsActive == true);
        }

        public async Task UpdateCategory(Category category)
        {
            await _unitOfWork.CommitAsync();
        }
    }
}
