using AKBlog.Core.Model;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace AKBlog.Core.Services
{
    public interface ICommentsService
    {
        IEnumerable<Comments> GetAllComments();
        Task<Comments> GetCommentById(int id);
        IEnumerable<Comments> GetAllWithPostWithPostId(int PostId);
        Task<Comments> CreateComment(Comments newComment);
    }
}
