using ProjekatASP.Application.Commands.Blogcommands;
using ProjekatASP.Application.Exceptions;
using ProjekatASP.DataAccess.Configuration;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.Commands.EfBlogCommands
{
    public class EfDeleteBlogCommand : IDeleteBlogCommand
    {
        private readonly Context context;

        public EfDeleteBlogCommand(Context context)
        {
            this.context = context;
        }

        public int Id => 15;

        public string Name => "Delete blog";

        public void Execute(int id)
        {
            var blog = context.Blogs.Find(id);

            if (blog == null)
            {
                throw new EntityNotFoundException(id, typeof(Blog));
            }
            if (blog.IsDeleted == true)
            {
                throw new DeletedException(id, typeof(Blog));
            }

            blog.DeletedAt = DateTime.Now;
            blog.IsActive = false;
            blog.IsDeleted = true;
            context.SaveChanges();
        }
    }
}
