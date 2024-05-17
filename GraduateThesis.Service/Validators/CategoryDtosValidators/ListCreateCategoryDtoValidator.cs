using FluentValidation;
using GraduateThesis.Core.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Validators.CategoryDtosValidators
{
    public class ListCreateCategoryDtoValidator : AbstractValidator<List<CreateCategoryDto>>
    {
        private readonly CreateCategoryDtoValidator _validator;

        public ListCreateCategoryDtoValidator(CreateCategoryDtoValidator validator)
        {
            _validator = validator;

            RuleForEach(dtoList => dtoList)
                .SetValidator(_validator);
        }
    }
}
