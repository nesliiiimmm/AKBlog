﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKBlog.API.DTO
{
    public class SaveCommentsDTO : Save_BaseClassDTO
    {
        public string Comment { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public int PostId { get; set; }
        public SavePostsDTO Post { get; set; }
        public int UserId { get; set; }
        public SaveUserDTO User { get; set; }
    }
}
