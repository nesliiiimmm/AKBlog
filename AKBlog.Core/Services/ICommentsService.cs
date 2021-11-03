using AKBlog.Core.Model;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace AKBlog.Core.Services
{
    public interface ICommentsService
    {
        Task<IEnumerable<Comments>> GetAllComments();
        Task<Comments> GetCommentById(int id);
        Task<IEnumerable<Comments>> GetAllWithPostWithPostId(int PostId);
        Task<Comments> CreateComment(Comments newComment);
        Task UpdateComment(Comments CommentToBeUpdated, Comments Comments);
        Task DeleteComment(Comments Comments);
    }
}
