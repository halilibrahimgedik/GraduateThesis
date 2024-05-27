using FluentValidation;
using GraduateThesis.Core.Dtos.AnnouncementDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Validations.AnnouncementValidators
{
    public class CreateAnnouncementDtoValidator : AbstractValidator<CreateAnnouncementDto>
    {
        public CreateAnnouncementDtoValidator()
        {
            RuleFor(x=>x.Message).NotEmpty().WithMessage("{PropertyName} can not be empty")
                    .MinimumLength(10).WithMessage("{PropertyName} requires at least 10 character.")
                    .MaximumLength(350).WithMessage("{PropertyName} could be maximum 350 character.");

            RuleFor(x => x.Header).NotEmpty().WithMessage("{PropertyName} can not be empty")
                .MaximumLength(40).WithMessage("{PropertyName} could be maximum 40 character.");

            RuleFor(x => x.ClubId).NotEmpty().WithMessage("{PropertyName} can not be empty.");

            RuleFor(x=>x.AppUserId).NotEmpty().WithMessage("{PropertyName} can not be empty.");
        }
    }
}
