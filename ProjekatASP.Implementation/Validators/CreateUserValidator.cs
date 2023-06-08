using FluentValidation;
using ProjekatASP.Application.DataTransfer;
using ProjekatASP.DataAccess.Configuration;
using System.Linq;

namespace ProjekatASP.Implementation.Validators
{
    public class CreateUserValidator : AbstractValidator<RegisterDTO>
    {
        public CreateUserValidator(Context context)
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LstName).NotEmpty();
            RuleFor(x => x.UserName).NotEmpty()
                .MinimumLength(4)
                .Must(x => !context.Users.Any(y => y.UserName == x))
                .WithMessage("Username must be unique");
            RuleFor(x => x.Email).NotEmpty()
                .EmailAddress()
                .Must(x => !context.Users.Any(y => y.Email == x))
                .WithMessage("Email must be unique");
            RuleFor(x => x.Password).NotEmpty()
                .MinimumLength(8).WithMessage("Password must have atleast 8 characters.");
            
        }
    }
}
