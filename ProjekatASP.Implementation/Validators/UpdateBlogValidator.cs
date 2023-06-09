using FluentValidation;
using ProjekatASP.Application.DataTransfer;
using ProjekatASP.DataAccess.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.Validators.BlogValidators
{
    public class UpdateBlogValidator : AbstractValidator<BlogDTO>
    {
        public UpdateBlogValidator(Context context)
        {
            RuleFor(x => x.Subject).NotEmpty().NotNull().WithMessage("Subject must be filled.");
            RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage("Subject must be filled.");
            RuleFor(x => x.Categories).NotNull().WithMessage("Categories must be selected");
        }
    }
}
