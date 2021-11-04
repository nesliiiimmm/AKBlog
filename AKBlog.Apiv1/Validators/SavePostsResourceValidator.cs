using AKBlog.Apiv1.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKBlog.Apiv1.Validators
{
    public class SavePostsResourceValidator: AbstractValidator<SavePostsDTO>
    {
        public SavePostsResourceValidator()
        {

            RuleFor(m => m.Name).NotEmpty().WithMessage("Name must not be empty.");
            RuleFor(m => m.Description).NotEmpty().WithMessage("Description must not be empty.");
            RuleFor(m => m.CategoryId).NotEmpty().WithMessage("CategoryId must not be empty.");
            RuleFor(m => m.UserId).NotEmpty().WithMessage("UserId must not be empty.");
            RuleFor(m => m.TagId).NotEmpty().WithMessage("TagId must not be empty.");
        }
    }
}
