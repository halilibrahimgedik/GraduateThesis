using FluentValidation;
using GraduateThesis.Core.Dtos.RoleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Validations.RoleDtosValidators
{
    public class AssignRoleDtoValidator : AbstractValidator<AssignRoleDto>
    {
        public AssignRoleDtoValidator()
        {
            RuleFor(x=>x.RoleId).NotEmpty().WithMessage("{PropertyName} can not be empty");

            RuleFor(x=>x.UserId).NotEmpty().WithMessage("{PropertyName} can not be empty");
        }
    }
}
