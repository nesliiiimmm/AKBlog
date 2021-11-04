using AKBlog.Apiv1.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKBlog.Apiv1.Validators
{
    public class SaveUserResourceValidator: AbstractValidator<SaveUserDTO>
    {
        public SaveUserResourceValidator()
        {
            RuleFor(m => m.UserName).NotEmpty().WithMessage("Username must not be empty.");
            RuleFor(m => m.Password).NotEmpty().WithMessage("Password must not be empty.");
            RuleFor(m => m.Name).NotEmpty().WithMessage("Name must not be empty.");
            RuleFor(m => m.Surname).NotEmpty().WithMessage("Surname must not be empty.");
            RuleFor(m => m.EMail).NotEmpty().WithMessage("Email must not be empty.");
            RuleFor(m => m.PhoneNumber).NotEmpty().WithMessage("PhoneNumber must not be empty.");


        }

        
    }
}
