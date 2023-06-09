using FluentValidation;
using ProjekatASP.Application.Commands.Blogcommands;
using ProjekatASP.Application.DataTransfer;
using ProjekatASP.Application.Util;
using ProjekatASP.DataAccess.Configuration;
using ProjekatASP.Domain;
using ProjekatASP.Implementation.Validators.ArticleValidators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.Commands.EfBlogCommands
{
    public class EfCreateBlogCommand : ICreateBlogCommand
    {
        private readonly Context _context;
        private readonly CreateBlogValidator _validator;
        private readonly IApplicationActor actor;

        public EfCreateBlogCommand(Context context, CreateBlogValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            this.actor = actor;
        }

        public int Id => 7;

        public string Name => "Create new blog.";

        public void Execute(BlogDTO request)
        {
            _validator.ValidateAndThrow(request);
            ICollection<BlogCategory> categoryBlogs = new List<BlogCategory>();
            foreach(var catId in request.CategoryIds)
            {
                var blogCategory = new BlogCategory
                {
                    CategoryId = catId
                };
                categoryBlogs.Add(blogCategory);
            }
            var blog = new Blog
            {
                Subject = request.Subject,
                Description = request.Description,
                BlogCategory = categoryBlogs,
                UserId = actor.Id
            };
            _context.Blogs.Add(blog);
            _context.SaveChanges();
        }
    }
}
