using FluentValidation;
using GraduateThesis.Core.Dtos.ClubDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Validators.ClubDtosValidations
{
    public class CreateClubDtoValidator : AbstractValidator<CreateClubDto>
    {
        public CreateClubDtoValidator()
        {
            RuleFor(c=>c.ClubName)
                .NotEmpty().WithMessage("{PropertyName} can not be empty")
                .MaximumLength(50).WithMessage("{PropertyName} field could be maximum 50 characters")
                .MinimumLength(3).WithMessage("{PropertyName} field must be at least 3 characters");


            RuleFor(c => c.ClubSummary)
                .NotEmpty().WithMessage("{PropertyName} can not be empty")
                .MaximumLength(450).WithMessage("{PropertyName} field could be maximum 450 characters")
                .MinimumLength(10).WithMessage("{PropertyName} field must be at least 10 characters");

            RuleFor(c => c.ClubPhoto)
                .NotEmpty().WithMessage("{PropertyName} can not be empty")
                .MaximumLength(300).WithMessage("{PropertyName} field could be maximum 300 characters");

            RuleFor(c => c.IsClubActive)
                .NotEmpty().WithMessage("{PropertyName} can not be empty");

            RuleFor(c => c.Categories)
                .NotEmpty().WithMessage("{PropertyName} can not be empty");
        }
    }
}
