using AKBlog.Core;
using AKBlog.Core.Repositories;
using AKBlog.Data.Contexts;
using AKBlog.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AKBlog.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AKBlogMSSQLDBContext _context;
        private CategoryRepository _categoryRepository;
        private CommentsRepository _commentsRepository;
        private TagsRepository _tagsRepository;
        private PostsRepository _postsRepository;
        private UserRepository _userRepository;
        public UnitOfWork(AKBlogMSSQLDBContext context)
        {
            this._context = context;

        }
        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);

        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);

        public ICommentsRepository Comments => _commentsRepository = _commentsRepository ?? new CommentsRepository(_context);

        public IPostsRepository Posts => _postsRepository = _postsRepository ?? new PostsRepository(_context);

        public ITagsRepository Tags => _tagsRepository = _tagsRepository ?? new TagsRepository(_context);

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
