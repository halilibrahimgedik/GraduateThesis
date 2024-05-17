using FluentValidation;
using GraduateThesis.Core.Dtos.LoginDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Service.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator() 
        {
            RuleFor(x=>x.Email).NotEmpty().WithMessage("Email address can not be empty")
                .EmailAddress().WithMessage("Invalid Email address");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password can not be empty");
        }
    }
}
