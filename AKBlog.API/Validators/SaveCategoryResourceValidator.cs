using AKBlog.API.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKBlog.API.Validators
{
    public class SaveCategoryResourceValidator: AbstractValidator<SaveCategoryDTO>
    {
        public SaveCategoryResourceValidator()
        {
            RuleFor(m => m.CategoryName).NotEmpty().WithMessage("'Name must not be empty.");
            
        }
    }
}
