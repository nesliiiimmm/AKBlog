﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKBlog.API.DTO
{
    public class SaveCategoryDTO:Save_BaseClassDTO
    {
        public string CategoryName { get; set; }
    }
}