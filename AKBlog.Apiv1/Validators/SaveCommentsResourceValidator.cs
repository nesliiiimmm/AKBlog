using AKBlog.Apiv1.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKBlog.Apiv1.Validators
{
    public class SaveCommentsResourceValidator: AbstractValidator<SaveCommentsDTO>
    {
        public SaveCommentsResourceValidator()
        {
            RuleFor(m => m.Comment).NotEmpty();
            RuleFor(m => m.Name).NotEmpty().WithMessage("'Name must not be empty.");
            RuleFor(m => m.EMail).NotEmpty().WithMessage("'EMail must not be empty.");
            RuleFor(m => m.PostId).NotEmpty().WithMessage("'Post must not be empty.");
            RuleFor(m => m.UserId).NotEmpty().WithMessage("'User must not be empty.");

        }
    }
}
