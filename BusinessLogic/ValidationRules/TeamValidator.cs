using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ValidationRules
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            // Team name
            RuleFor(x => x.TeamName).NotEmpty().WithMessage("Team name cannot be empty.");
            RuleFor(x => x.TeamName).MaximumLength(50).WithMessage("Team name cannot be more than 50 characters.");
            RuleFor(x => x.TeamName).MinimumLength(5).WithMessage("Team name cannot be less than 5 characters.");

            // Team image
            RuleFor(x => x.TeamImage).NotEmpty().WithMessage("Team image cannot be empty");

            // Team description
            RuleFor(x => x.TeamDescription).NotEmpty().WithMessage("Team description cannot be empty");
            RuleFor(x => x.TeamDescription).MaximumLength(200).WithMessage("Team description cannot be more than 200 characters.");
            RuleFor(x => x.TeamDescription).MinimumLength(20).WithMessage("Team description cannot be more than 20 characters.");
        }
    }
}
