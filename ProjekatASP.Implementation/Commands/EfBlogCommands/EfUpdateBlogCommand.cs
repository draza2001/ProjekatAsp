using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProjekatASP.Application.Commands.Blogcommands;
using ProjekatASP.Application.DataTransfer;
using ProjekatASP.Application.Exceptions;
using ProjekatASP.DataAccess.Configuration;
using ProjekatASP.Domain;
using ProjekatASP.Implementation.Validators.BlogValidators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.Commands.EfBlogCommands
{
    public class EfUpdateBlogCommand : IUpdateBlogCommand
    {
        private readonly Context context;
        private readonly UpdateBlogValidator validator;

        public EfUpdateBlogCommand(Context context, UpdateBlogValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id => 14;

        public string Name => "Update blog";

        public void Execute(BlogDTO request, int id)
        {
            var blog = context.Blogs.Find(id);

            if (blog == null)
            {
                throw new EntityNotFoundException(id, typeof(Blog));
            }
            context.Database.ExecuteSqlRaw($"Delete from BlogCategories where BlogId = {id}");
            validator.ValidateAndThrow(request);

            blog.Subject = request.Subject;
            blog.Description = request.Description;
            blog.ModifiedAt = DateTime.Now;
            var categoryIds = request.CategoryIds;

            ICollection<BlogCategory> blogCategories = new List<BlogCategory>();

            foreach(var categoryId in categoryIds)
            {
                var blogCategory = new BlogCategory
                {
                    BlogId = id,
                    CategoryId = categoryId
                };
                blogCategories.Add(blogCategory);
            }
            blog.BlogCategory = blogCategories;
            context.SaveChanges();
        }
    }
}
