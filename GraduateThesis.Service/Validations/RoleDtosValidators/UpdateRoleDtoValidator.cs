using FluentValidation;
using GraduateThesis.Core.Dtos.RoleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Validations.RoleDtosValidators
{
    public class UpdateRoleDtoValidator : AbstractValidator<UpdateRoleDto>
    {
        public UpdateRoleDtoValidator()
        {
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("{PropertyName} can not be empty");

            RuleFor(x => x.RoleName).NotEmpty().WithMessage("{PropertyName} can not be empty")
                .MinimumLength(3).WithMessage("RoleName requires at least 3 characters length");
        }
    }
}
