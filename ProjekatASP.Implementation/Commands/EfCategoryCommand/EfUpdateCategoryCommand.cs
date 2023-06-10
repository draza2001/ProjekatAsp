using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using ProjekatASP.Application.Commands.CategoryCommands;
using ProjekatASP.Application.DataTransfer;
using ProjekatASP.Application.Exceptions;
using ProjekatASP.DataAccess.Configuration;
using ProjekatASP.Domain;
using ProjekatASP.Implementation.Validators;

namespace ProjekatASP.Implementation.Commands.EfCategoryCommand
{
    public class EfUpdateCategoryCommand : IUpdateCategoryCommand
    {
        private readonly Context _context;
        private readonly CreateCategoryValidator _validator;

        public EfUpdateCategoryCommand(Context context, CreateCategoryValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 11;

        public string Name => "Update category";

        public void Execute(CategoryDTO request, int id)
        {
            var category = _context.Categories.Find(id);

            if(category == null)
            {
                throw new EntityNotFoundException(id, typeof(Category));
            }
            _validator.ValidateAndThrow(request);

            category.Name = request.Name;
            category.ModifiedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
