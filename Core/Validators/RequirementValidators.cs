using Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validators
{
    public class RequirementValidators : AbstractValidator<RequirementDTO>
    {
        public RequirementValidators()
        {
            RuleFor(r => r.Name)
                    .NotEmpty()
                    .NotNull()
                    .MinimumLength(5);
        }
    }
}
