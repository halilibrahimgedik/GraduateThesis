using FluentValidation;
using GraduateThesis.Core.Dtos.MemberDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Validations.MemberDtosValidator
{
    public class CreateMemberDtoValidator : AbstractValidator<CreateMemberDto>
    {
        public CreateMemberDtoValidator()
        {
            RuleFor(s => s.UserId).NotEmpty().WithMessage("{PropertyName} can not be empty.");

            RuleFor(s=>s.ClubId).NotEmpty().WithMessage("{PropertyName} can not be empty.");
        }
    }
}
