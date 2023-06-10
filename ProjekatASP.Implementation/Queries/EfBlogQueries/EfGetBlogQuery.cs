using ProjekatASP.Application.DataTransfer;
using ProjekatASP.Application.Exceptions;
using ProjekatASP.Application.Queries.BlogQuery;
using ProjekatASP.DataAccess.Configuration;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.Queries.EfBlogQueries
{
    public class EfGetBlogQuery : IGetBlogQuery
    {
        private readonly Context context;

        public EfGetBlogQuery(Context context)
        {
            this.context = context;
        }

        public int Id => 13;

        public string Name => "Get one blog";

        public BlogDTO Execute(int id)
        {
            var blog = context.Blogs.Find(id);

            var categoryIds = context.BlogCategories.Where(x => x.BlogId == id).Select(x => x.CategoryId).ToList();
            var images = context.Pictures.Where(p => p.BlogId == id).Select(p => p.Src).ToList();

            if (blog == null)
            {
                throw new EntityNotFoundException(id, typeof(Blog));
            }

            var result = new BlogDTO
            {
                Id = blog.Id,
                Subject = blog.Subject,
                Description = blog.Description,
                CategoryIds = categoryIds,
                Images = images
            };

            return result;
        }
    }
}
