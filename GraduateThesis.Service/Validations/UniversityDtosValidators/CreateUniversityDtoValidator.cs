﻿using FluentValidation;
using GraduateThesis.Core.Dtos.UniversityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Validators.UniversityDtosValidators
{
    public class CreateUniversityDtoValidator : AbstractValidator<CreateUniversityDto>
    {
        public CreateUniversityDtoValidator()
        {
            RuleFor(x=>x.UniversityName)
                .NotEmpty().WithMessage("{PropertyName} can not be empty")
                .MaximumLength(100).WithMessage("{PropertyName} field could be maximum 100 characters")
                .MinimumLength(16).WithMessage("{PropertyName} field must be at least 16 characters");

            RuleFor(x => x.Website)
                .NotEmpty().WithMessage("{PropertyName} can not be empty");

            RuleFor(x => x.Mail)
                .NotEmpty().WithMessage("{PropertyName} can not be empty");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("{PropertyName} can not be empty");
        }
    }
}
