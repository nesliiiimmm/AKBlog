using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKBlog.API.DTO
{
    public class SavePostsDTO : Save_BaseClassDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public SaveCategoryDTO Category { get; set; }
        public int UserId { get; set; }
        public SaveUserDTO User { get; set; }
        public int TagId { get; set; }
        public SaveTagsDTO Tag { get; set; }
        public string ImageUrl { get; set; }
        public int PostViewCount { get; set; }
    }
}
