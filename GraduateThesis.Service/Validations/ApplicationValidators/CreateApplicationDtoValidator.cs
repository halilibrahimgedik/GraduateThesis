using FluentValidation;
using GraduateThesis.Core.Dtos.ApplicationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Validations.ApplicationValidators
{
    public class CreateApplicationDtoValidator : AbstractValidator<CreateApplicationDto>
    {
        public CreateApplicationDtoValidator()
        {
            
            RuleFor(x=>x.AppUserId).NotEmpty().WithMessage("{PropertyName} can not be empty");
            RuleFor(x=>x.ClubId).NotEmpty().WithMessage("{PropertyName} can not be empty");
            RuleFor(x=>x.CvFile).NotEmpty().WithMessage("{PropertyName} can not be empty");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("{PropertyName} can not be empty")
                .MinimumLength(10).WithMessage("{PropertyName} requires at least 10 character letter");
        }
    }
}
