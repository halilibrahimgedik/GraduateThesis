using FluentValidation;
using GraduateThesis.Core.Dtos.SubscriberDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Validations.SubscriberDtosValidator
{
    public class SubscriberIdDtoValidator : AbstractValidator<SubscriberIdDto>
    {
        public SubscriberIdDtoValidator()
        {
            RuleFor(s => s.UserId).NotEmpty().WithMessage("{PropertyName} can not be empty.");
        }
    }
}
