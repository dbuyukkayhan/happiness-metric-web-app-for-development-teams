using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Entities.Concrete;

namespace BusinessLogic.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            // User Name
            RuleFor(x => x.UserName).NotEmpty().WithMessage("This area cannot be empty");
            RuleFor(x => x.UserName).MinimumLength(2).WithMessage("User name lenght cannot be less than 2 characters.");
            RuleFor(x => x.UserName).MaximumLength(2).WithMessage("User name lenght cannot be more than 30 characters.");

            // E-mail
            RuleFor(x => x.UserEmail).NotEmpty().WithMessage("This area cannot be empty.");
            RuleFor(x => x.UserEmail).EmailAddress().WithMessage("Invalid e-mail address.");
            
            // Password
            RuleFor(x => x.UserPassword).NotEmpty().WithMessage("This area cannot be empty");
        }
    }
}
