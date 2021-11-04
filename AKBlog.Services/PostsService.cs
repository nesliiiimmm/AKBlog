using AKBlog.Core;
using AKBlog.Core.Model;
using AKBlog.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AKBlog.Services
{
    public class PostsService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PostsService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Posts> CreatePost(Posts newPost)
        {
            await _unitOfWork.Posts.AddAsync(newPost);
            await _unitOfWork.CommitAsync();
            return newPost;
        }

        public async Task DeletePost(Posts Post)
        {
            Post.IsActive = false;
            await _unitOfWork.CommitAsync();
        }

        public IEnumerable<Posts> GetAllPosts()
        {
            return _unitOfWork.Posts.Where(x => x.IsActive == true);
        }
        public IEnumerable<Posts> GetAllCategoryWithCategoryId(int CategoryId)
        {
            return _unitOfWork.Posts.Where(x =>x.CategoryId==CategoryId&& x.IsActive == true);
        }

        public IEnumerable<Posts> GetAllWithTagWithTagId(int TagId)
        {
            return _unitOfWork.Posts.Where(x => x.TagId == TagId && x.IsActive == true);
        }

        public IEnumerable<Posts> GetAllWithUserWithUserId(int UserId)
        {

            return _unitOfWork.Posts.Where(x => x.UserId == UserId && x.IsActive == true);
        }

        public async Task<Posts> GetPostById(int id)
        {
            return await _unitOfWork.Posts.FirstOrDefaultAsync(x => x.ID == id && x.IsActive == true);
        }

        public async Task UpdatePost(Posts Post)
        {
            await _unitOfWork.CommitAsync();
        }
    }
}
