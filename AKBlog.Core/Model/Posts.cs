using AKBlog.Core.Model.Temp;
using System;
using System.Collections.Generic;
using System.Text;

namespace AKBlog.Core.Model
{
    public class Posts:_BaseClass
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int TagId { get; set; }
        public Tags Tag { get; set; }
        public string ImageUrl { get; set; }
        public int PostViewCount { get; set; }
        public ICollection<Comments> Comments { get; set; }

    }
}
