using FluentValidation;
using GraduateThesis.Core.Dtos.CategoryDtos;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Validators.CategoryDtosValidators
{
    public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator()
        {
            RuleFor(c => c.Name)
                .NotNull().WithMessage("{PropertyName} can not be null")
                .NotEmpty().WithMessage("{PropertyName} can not be empty")
                .MaximumLength(50).WithMessage("{PropertyName} field could be maximum 50 characters")
                .MinimumLength(3).WithMessage("{PropertyName} field must be at least 3 characters")
                .Must(name => !string.IsNullOrWhiteSpace(name)).WithMessage("{PropertyName} field cannot be empty or whitespace");
        }
    }
}
