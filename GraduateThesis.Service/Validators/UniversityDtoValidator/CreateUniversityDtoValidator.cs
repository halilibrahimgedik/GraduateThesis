using FluentValidation;
using GraduateThesis.Core.Dtos.UniversityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Validators.UniversityDtoValidator
{
    public class CreateUniversityDtoValidator : AbstractValidator<CreateUniversityDto>
    {
        public CreateUniversityDtoValidator()
        {
            RuleFor(x=>x.UniversityName)
                .NotEmpty().WithMessage("{PropertyName} can not be empty")
                .MaximumLength(100).WithMessage("{PropertyName} en fazla 100 karakter olabilir")
                .MinimumLength(16).WithMessage("{PropertyName} en az 16 karakter olabilir");

            RuleFor(x => x.Website)
                .NotEmpty().WithMessage("{PropertyName} can not be empty");

            RuleFor(x => x.Mail)
                .NotEmpty().WithMessage("{PropertyName} can not be empty");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("{PropertyName} can not be empty");
        }
    }
}
