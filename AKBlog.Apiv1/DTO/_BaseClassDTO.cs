using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKBlog.Apiv1.DTO
{
    public class _BaseClassDTO
    {
        public int ID { get; set; }
        public int? CreatedUser { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public int? UpdatedUser { get; set; }
        public bool? IsActive { get; set; }
    }
}
