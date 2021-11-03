using AKBlog.Core.Model.Temp;
using System;
using System.Collections.Generic;
using System.Text;

namespace AKBlog.Core.Model
{
    public class Comments:_BaseClass
    {
        public string Comment { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public int PostId { get; set; }
        public Posts Post { get; set; }
    }
}
