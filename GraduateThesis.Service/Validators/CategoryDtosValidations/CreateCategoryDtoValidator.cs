using FluentValidation;
using GraduateThesis.Core.Dtos.CategoryDtos;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Validators.CategoryDtosValidations
{
    public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator()
        {
            RuleFor(c => c.CategoryName)
                .NotEmpty().WithMessage("{PropertyName} can not be empty")
                .MaximumLength(50).WithMessage("{PropertyName} en fazla 50 karakter olabilir")
                .MinimumLength(3).WithMessage("{PropertyName} en az 3 karakter olabilir");
        }
    }
}
