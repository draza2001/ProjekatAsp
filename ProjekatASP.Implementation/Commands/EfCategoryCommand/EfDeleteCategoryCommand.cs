using ProjekatASP.Application.Commands.CategoryCommands;
using ProjekatASP.Application.Commands.Usercommands;
using ProjekatASP.Application.Exceptions;
using ProjekatASP.DataAccess.Configuration;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.Commands.EfCategoryCommand
{
    public class EfDeleteCategoryCommand : IDeleteCategoryCommand
    {
        private readonly Context context;

        public EfDeleteCategoryCommand(Context context)
        {
            this.context = context;
        }

        public int Id => 12;

        public string Name => "Deleting category";

        public void Execute(int id)
        {
            var category = context.Categories.Find(id);

            if (category == null)
            {
                throw new EntityNotFoundException(id, typeof(Category));
            }
            if (category.IsDeleted == true)
            {
                throw new DeletedException(id, typeof(Category));
            }

            category.DeletedAt = DateTime.Now;
            category.IsActive = false;
            category.IsDeleted = true;
            context.SaveChanges();

        }
    }
}
