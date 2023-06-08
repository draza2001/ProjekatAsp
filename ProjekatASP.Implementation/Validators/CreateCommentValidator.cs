using FluentValidation;
using ProjekatASP.Application.DataTransfer;
using ProjekatASP.DataAccess.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.Validators
{
    public class CreateCommentValidator : AbstractValidator<CommentDTO>
    {
        public CreateCommentValidator(Context context)
        {
            RuleFor(x => x.Text).NotEmpty().WithMessage("Text must be filled");
        }
    }
}
