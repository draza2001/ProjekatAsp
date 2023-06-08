using FluentValidation;
using ProjekatASP.Application.DataTransfer;
using ProjekatASP.DataAccess.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.Validators
{
    public class CreateCategoryValidator : AbstractValidator<CategoryDTO>
    {
        public CreateCategoryValidator(Context context)
        {
            RuleFor(x => x.Name).NotEmpty().Must(name => !context.Categories.Any(y => y.Name == name)).WithMessage("Category name must be unique");
        }
    }
}
