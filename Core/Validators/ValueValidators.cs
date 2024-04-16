using Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validators
{
    public class ValueValidators : AbstractValidator<ValueDTO>
    {
        public ValueValidators() 
        {
            RuleFor(v => v.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(1);
        }
    }
}
