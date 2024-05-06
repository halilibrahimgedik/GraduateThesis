using FluentValidation;
using GraduateThesis.Core.Dtos.ClubDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Validators.ClubDtosValidations
{
    public class ClubDtoValidator : AbstractValidator<ClubDto>
    {
        public ClubDtoValidator()
        {
            RuleFor(c => c.ClubName)
               .NotEmpty().WithMessage("{PropertyName} can not be empty")
               .MaximumLength(50).WithMessage("{PropertyName} en fazla 50 karakter olabilir")
               .MinimumLength(3).WithMessage("{PropertyName} en az 3 karakter olabilir");


            RuleFor(c => c.ClubSummary)
                .NotEmpty().WithMessage("{PropertyName} can not be empty")
                .MaximumLength(450).WithMessage("{PropertyName} en fazla 450 karakter olabilir")
                .MinimumLength(10).WithMessage("{PropertyName} en az 10 karakter olabilir");

            RuleFor(c => c.ClubPhoto)
                .NotEmpty().WithMessage("{PropertyName} can not be empty")
                .MaximumLength(300).WithMessage("{PropertyName} en fazla 300 karakter olabilir");

            RuleFor(c => c.IsClubActive)
                .NotEmpty().WithMessage("{PropertyName} can not be empty");
        }
    }
}
