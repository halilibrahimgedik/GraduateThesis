using FluentValidation;
using GraduateThesis.Core.Dtos.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Validations.AppUserDtosValidators
{
    public class UpdateAppUserDtoValidator : AbstractValidator<UpdateAppUserDto>
    {
        public UpdateAppUserDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("User Id can not be empty");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email adress can not be empty")
                .EmailAddress().WithMessage("Invalid Email address");


            RuleFor(x => x.Password).NotEmpty().WithMessage("Password can not be empty")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters")
                .Must(password => password.Any(char.IsUpper)).WithMessage("Password must contains at least 1 uppercase letter")
                .Must(password => password.Any(char.IsLower)).WithMessage("Password must contains at least 1 lowercase letter")
                .Must(password => password.Any(char.IsDigit)).WithMessage("Password must contains at least 1 digit");


            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username can not be empty");

            RuleFor(x => x.UniversityId).NotEmpty().WithMessage("UniversityId can not be empty");
        }
    }
}
