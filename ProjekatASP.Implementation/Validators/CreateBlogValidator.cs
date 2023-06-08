using FluentValidation;
using ProjekatASP.Application.DataTransfer;
using ProjekatASP.DataAccess.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.Validators.ArticleValidators
{
    public class CreateBlogValidator : AbstractValidator<BlogDTO>
    {
        public CreateBlogValidator(Context context)
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage("You must fill subject.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Post must have description.");

        }
    }
}
