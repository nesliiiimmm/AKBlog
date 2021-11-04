using AKBlog.Core;
using AKBlog.Core.Model;
using AKBlog.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AKBlog.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentsService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Comments> CreateComment(Comments newComment)
        {
            await _unitOfWork.Comments.AddAsync(newComment);
            await _unitOfWork.CommitAsync();
            return newComment;
        }

        public IEnumerable<Comments> GetAllComments()
        {
            return  _unitOfWork.Comments.Where(x => x.IsActive == true);
        }

        public IEnumerable<Comments> GetAllWithPostWithPostId(int PostId)//Sql Injection olur mu kontrol et ?
        {
            return _unitOfWork.Comments.Where(x =>x.PostId==PostId && x.IsActive == true);
        }

        public async Task<Comments> GetCommentById(int id)
        {
            return await _unitOfWork.Comments.FirstOrDefaultAsync(x => x.ID == id && x.IsActive == true);
        }
    }
}
