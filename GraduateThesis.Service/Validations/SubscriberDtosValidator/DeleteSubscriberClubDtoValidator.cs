using FluentValidation;
using GraduateThesis.Core.Dtos.SubscriberDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Validations.SubscriberDtosValidator
{
    public class DeleteSubscriberClubDtoValidator : AbstractValidator<DeleteSubscriberClubDto>
    {
        public DeleteSubscriberClubDtoValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("{PropertyName} can not be empty.");

            RuleFor(x => x.ClubId).NotEmpty().WithMessage("{PropertyName} can not be empty.");
        }
    }
}
