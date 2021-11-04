using AKBlog.Core.Model;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace AKBlog.Core.Services
{
    public interface ITagsService
    {
        IEnumerable<Tags> GetAllTags();
        Task<Tags> GetTagById(int id);
        Task<Tags> CreateTag(Tags newTag);
        Task UpdateTag(Tags Tag);
        Task DeleteTag(Tags Tag);
    }
}
