using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKBlog.API.DTO
{
    public class PostsDTO:_BaseClassDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }
        public int TagId { get; set; }
        public TagsDTO Tag { get; set; }
        public string ImageUrl { get; set; }
        public int PostViewCount { get; set; }
    }
}
