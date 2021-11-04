using AKBlog.Core.Model.Temp;
using System;
using System.Collections.Generic;
using System.Text;

namespace AKBlog.Core.Model
{
    public class User:_BaseClass
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
    }
}
