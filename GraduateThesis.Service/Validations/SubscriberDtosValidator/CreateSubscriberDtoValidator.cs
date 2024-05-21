using FluentValidation;
using GraduateThesis.Core.Dtos.SubscriberDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Validations.SubscriberDtosValidator
{
    public class CreateSubscriberDtoValidator : AbstractValidator<CreateSubscriberDto>
    {
        public CreateSubscriberDtoValidator()
        {
            RuleFor(s => s.UserId).NotEmpty().WithMessage("{PropertyName} can not be empty.");

            RuleFor(s=>s.ClubId).NotEmpty().WithMessage("{PropertyName} can not be empty.");
        }
    }
}
