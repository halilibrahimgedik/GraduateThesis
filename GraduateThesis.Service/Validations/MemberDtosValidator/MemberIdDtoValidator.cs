using FluentValidation;
using GraduateThesis.Core.Dtos.MemberDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Validations.SubscriberDtosValidator
{
    public class MemberIdDtoValidator : AbstractValidator<MemberIdDto>
    {
        public MemberIdDtoValidator()
        {
            RuleFor(s => s.UserId).NotEmpty().WithMessage("{PropertyName} can not be empty.");
        }
    }
}
