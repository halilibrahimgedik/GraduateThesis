using FluentValidation;
using GraduateThesis.Core.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Validators.CategoryDtosValidations
{
    public class CategoryDtoValidator : AbstractValidator<CategoryDto>
    {
        public CategoryDtoValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("{PropertyName} can not be empty")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than '0'"); ;

            RuleFor(c => c.CategoryName)
                .NotEmpty().WithMessage("{PropertyName} can not be empty")
                .MaximumLength(50).WithMessage("{PropertyName} field could be maximum 50 characters")
                .MinimumLength(3).WithMessage("{PropertyName} field must be at least 3 characters");
        }
    }
}
