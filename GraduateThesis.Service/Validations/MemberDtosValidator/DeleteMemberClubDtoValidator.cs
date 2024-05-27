using FluentValidation;
using GraduateThesis.Core.Dtos.MemberDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Validations.MemberDtosValidator
{
    public class DeleteMemberClubDtoValidator : AbstractValidator<DeleteMemberClubDto>
    {
        public DeleteMemberClubDtoValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("{PropertyName} can not be empty.");

            RuleFor(x => x.ClubId).NotEmpty().WithMessage("{PropertyName} can not be empty.");
        }
    }
}
