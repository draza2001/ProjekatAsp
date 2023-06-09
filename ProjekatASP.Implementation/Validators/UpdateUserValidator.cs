using FluentValidation;
using ProjekatASP.Application.DataTransfer;
using ProjekatASP.DataAccess.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.Validators
{
    public class UpdateUserValidator : AbstractValidator<UserDTO>
    {
        public UpdateUserValidator(Context context)
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.UserName).NotEmpty()
                .MinimumLength(4)
                .Must(x => !context.Users.Any(y => y.UserName == x))
                .WithMessage("Username must be unique");
            RuleFor(x => x.Email).NotEmpty()
                .EmailAddress()
                .Must(x => !context.Users.Any(y => y.Email == x))
                .WithMessage("Email must be unique");


        }
    }
}
