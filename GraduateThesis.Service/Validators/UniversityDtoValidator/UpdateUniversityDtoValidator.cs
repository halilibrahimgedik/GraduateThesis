using FluentValidation;
using GraduateThesis.Core.Dtos.UniversityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Validators.UniversityDtoValidator
{
    public class UpdateUniversityDtoValidator : AbstractValidator<UpdateUniversityDto>
    {
        public UpdateUniversityDtoValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty().WithMessage("{PropertyName} can not be empty")
               .NotNull().WithMessage("{PropertyName} can not be null");

            RuleFor(x => x.UniversityName)
               .NotEmpty().WithMessage("{PropertyName} can not be empty")
               .NotNull().WithMessage("{PropertyName} can not be null")
               .MaximumLength(100).WithMessage("{PropertyName} en fazla 100 karakter olabilir")
               .MinimumLength(16).WithMessage("{PropertyName} en az 16 karakter olabilir");

            RuleFor(x => x.Website)
                .NotEmpty().WithMessage("{PropertyName} can not be empty")
                .NotNull().WithMessage("{PropertyName} can not be null");

            RuleFor(x => x.Mail)
                .NotEmpty().WithMessage("{PropertyName} can not be empty")
                .NotNull().WithMessage("{PropertyName} can not be null");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("{PropertyName} can not be empty")
                .NotNull().WithMessage("{PropertyName} can not be null");
        }
    }
}
