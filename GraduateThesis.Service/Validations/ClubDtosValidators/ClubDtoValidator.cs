using FluentValidation;
using GraduateThesis.Core.Dtos.ClubDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Validators.ClubDtosValidators
{
    public class ClubDtoValidator : AbstractValidator<ClubDto>
    {
        public ClubDtoValidator()
        {
            RuleFor(x=>x.Id)
                .NotEmpty().WithMessage("{PropertyName} can not be empty")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than '0'");

            RuleFor(c => c.Name)
               .NotEmpty().WithMessage("{PropertyName} can not be empty")
               .MaximumLength(50).WithMessage("{PropertyName} field could be maximum 50 characters")
               .MinimumLength(3).WithMessage("{PropertyName} field must be at least 3 characters");


            RuleFor(c => c.Summary)
                .NotEmpty().WithMessage("{PropertyName} can not be empty")
                .MaximumLength(450).WithMessage("{PropertyName} field could be maximum 450 characters")
                .MinimumLength(10).WithMessage("{PropertyName} field must be at least 10 characters");

            RuleFor(c => c.Url)
                .MaximumLength(300).WithMessage("{PropertyName} field could be maximum 300 characters");

            RuleFor(c => c.IsActive)
                .NotEmpty().WithMessage("{PropertyName} can not be empty");
        }
    }
}
