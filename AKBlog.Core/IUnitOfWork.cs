using AKBlog.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AKBlog.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ICategoryRepository Categories { get; }
        ICommentsRepository Comments { get; }
        IPostsRepository Posts { get; }
        ITagsRepository Tags { get; }
        Task<int> CommitAsync();
        int Commit();
    }
}
