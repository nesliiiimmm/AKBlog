using System;
using System.Collections.Generic;
using System.Text;

namespace AKBlog.Core.Model.Temp
{
    public class _BaseClass
    {
        public int ID { get; set; }
        public int? CreatedUser { get; set; } 
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public int? UpdatedUser { get; set; }
        public bool IsActive { get; set; }
    }

}
