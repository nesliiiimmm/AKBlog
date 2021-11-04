using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKBlog.API.DTO
{
    public class CommentsDTO:_BaseClassDTO
    {
        public string Comment { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public int PostId { get; set; }
        public PostsDTO Post { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }
    }
}
