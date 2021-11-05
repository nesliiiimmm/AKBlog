using AKBlog.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AKBlog.Core.Interfaces
{
    public interface IJwtAuth
    {
        string Authentication(User user);
    }
}
