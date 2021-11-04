using System;
using System.Collections.Generic;
using System.Text;

namespace AKBlog.Core.Helper
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public dynamic Data { get; set; }
    }
}
