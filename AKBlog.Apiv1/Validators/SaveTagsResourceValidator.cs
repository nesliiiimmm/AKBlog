using AKBlog.Apiv1.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKBlog.Apiv1.Validators
{
    public class SaveTagsResourceValidator: AbstractValidator<SaveTagsDTO>
    {
        public SaveTagsResourceValidator()
        {
            RuleFor(m => m.Tag).NotEmpty().WithMessage("Tag must not be empty.");

        }
    }
}
