using AKBlog.Core;
using AKBlog.Core.Model;
using AKBlog.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AKBlog.Services
{
    public class TagsService : ITagsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TagsService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Tags> CreateTag(Tags newTag)
        {
            await _unitOfWork.Tags.AddAsync(newTag);
            await _unitOfWork.CommitAsync();
            return newTag;
        }

        public async Task DeleteTag(Tags Tag)
        {
            Tag.IsActive = false;
            await _unitOfWork.CommitAsync();
        }

        public IEnumerable<Tags> GetAllTags()
        {
            return  _unitOfWork.Tags.Where(x => x.IsActive == true);
        }

        public async Task<Tags> GetTagById(int id)
        {
            return await _unitOfWork.Tags.FirstOrDefaultAsync(x => x.ID == id && x.IsActive == true);
        }

        public async Task UpdateTag(Tags Tag)
        {
            await _unitOfWork.CommitAsync();
        }
    }
}
