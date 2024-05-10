using FluentValidation;
using GraduateThesis.Core.Dtos.ClubDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Validators.ClubDtosValidations
{
    public class CreateClubWithImageDtoValidator : AbstractValidator<CreateClubWithImageDto>
    {
        public CreateClubWithImageDtoValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} can not be empty...")
                .MaximumLength(50).WithMessage("{PropertyName} field could be maximum 50 characters...")
                .MinimumLength(3).WithMessage("{PropertyName} field must be at least 3 characters...");


            RuleFor(c => c.Summary)
                .NotEmpty().WithMessage("{PropertyName} can not be empty...")
                .MaximumLength(450).WithMessage("{PropertyName} field could be maximum 450 characters...")
                .MinimumLength(10).WithMessage("{PropertyName} field must be at least 10 characters...");

            RuleFor(c => c.IsActive)
                .NotEmpty().WithMessage("{PropertyName} can not be empty");

            RuleFor(c => c.Categories)
                .Must(categories => categories != null && categories.All(cat => cat != 0)).WithMessage("Categories can't Contains 0 id ")
                .NotEmpty().WithMessage("{PropertyName} can not be empty ...");

            RuleFor(c => c.Image).NotEmpty().WithMessage("{PropertyName} can not be empty...");
        }
    }
}
