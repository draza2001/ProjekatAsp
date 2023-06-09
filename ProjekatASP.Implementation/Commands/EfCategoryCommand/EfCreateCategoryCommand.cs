using FluentValidation;
using ProjekatASP.Application.Commands.CategoryCommands;
using ProjekatASP.Application.DataTransfer;
using ProjekatASP.DataAccess.Configuration;
using ProjekatASP.Domain;
using ProjekatASP.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.Commands.EfCategoryCommand
{
    public class EfCreateCategoryCommand : ICreateCategoryCommand
    {
        private readonly Context _context;
        private readonly CreateCategoryValidator _validator;

        public EfCreateCategoryCommand(Context context, CreateCategoryValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 8;

        public string Name => "Create new category";

        public void Execute(CategoryDTO request)
        {
            _validator.ValidateAndThrow(request);

            var category = new Category
            {
                Name = request.Name
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
    }
}
