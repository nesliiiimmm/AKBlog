using AKBlog.Core;
using AKBlog.Core.Helper;
using AKBlog.Core.Model;
using AKBlog.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var posts = _unitOfWork.Posts.Where(x => x.IsActive == true);
            var category = _unitOfWork.Categories.Where(x => x.IsActive == true);
            var result = (from p in posts
                          join
          c in category on p.CategoryId
          equals c.ID
                          select p).ToList();
            return result;
        }
        public IEnumerable<Posts> GetAllCategoryWithCategoryId(int CategoryId)
        {
            return _unitOfWork.Posts.Where(x => x.CategoryId == CategoryId && x.IsActive == true);
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
            //getpost inner join 
            return await _unitOfWork.Posts.FirstOrDefaultAsync(x => x.ID == id && x.IsActive == true);
        }

        public async Task UpdatePost(Posts Post)
        {
            Posts p = await _unitOfWork.Posts.FirstOrDefaultAsync(x => x.ID == Post.ID && x.IsActive == true);
            if (string.IsNullOrEmpty(Post.Name))
                p.Name = Post.Name;
            if (string.IsNullOrEmpty(Post.Description))
                p.Description = Post.Description;
            if (Post.CategoryId != null && Post.CategoryId != 0)
                p.CategoryId = Post.CategoryId;
            if (Post.PostViewCount != null && Post.PostViewCount != 0)
                p.PostViewCount = Post.PostViewCount;
            if (Post.UserId != null && Post.UserId != 0)
                p.UserId = Post.UserId;
            if(Post.TagId != null && Post.TagId != 0)
                p.TagId = Post.TagId;
            if (string.IsNullOrEmpty(Post.ImageUrl))
                p.ImageUrl = Post.ImageUrl;
            await _unitOfWork.CommitAsync();
        }

        public List<Posts> GetBestRead5()
        {
            var res = _unitOfWork.Posts.Where(x => x.IsActive == true).ToList();//In this
            List<Posts> last5post = (List<Posts>)res.OrderByDescending(s => s.PostViewCount);
            return last5post;
        }

        public IEnumerable<Posts> GetPostsWithPaging(PageParameters ownerParameters)
        {
            return GetAllPosts().OrderBy(on => on.ID)
                    .Skip((ownerParameters.PageNumber - 1) * ownerParameters.PageSize)
                    .Take(ownerParameters.PageSize)
                    .ToList();
        }

        public IEnumerable<Posts> GetPostsWithPagingandCategoryName(PageParameters ownerParameters, string name)
        {
            var Category = _unitOfWork.Categories.FirstOrDefaultAsync(x => x.CategoryName == name);
            return _unitOfWork.Posts.Where(x => x.IsActive == true && x.CategoryId == Category.Result.ID)
                .OrderBy(on => on.ID)
                .Skip((ownerParameters.PageNumber - 1) * ownerParameters.PageSize)
                .Take(ownerParameters.PageSize)
                .ToList();
        }
    }
}
