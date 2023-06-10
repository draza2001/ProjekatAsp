using ProjekatASP.Application.DataTransfer;
using ProjekatASP.Application.Queries.BlogQuery;
using ProjekatASP.Application.Queries.Pagination;
using ProjekatASP.Application.Searches;
using ProjekatASP.DataAccess.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.Queries.EfBlogQueries
{
    public class EfGetBlogsQuery : IGetBlogsQuery
    {
        private readonly Context _context;

        public EfGetBlogsQuery(Context context)
        {
            _context = context;
        }

        public int Id => 6;

        public string Name => "Blog Search";

        public PagedResponse<BlogDTO> Execute(Search search)
        {
            var query = _context.Blogs.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Subject.ToLower().Contains(search.Name.ToLower()));
            }
            query = query.Where(x => x.IsActive == true);


            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<BlogDTO>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new BlogDTO
                {
                    Id = x.Id,
                    Subject = x.Subject,
                    Description = x.Description,
                }).ToList()
            };
            foreach(var blog in response.Items)
            {
                blog.Categories = _context.BlogCategories.Where(c => c.BlogId == blog.Id).Select(c => new CategoryDTO
                {
                    Id = c.CategoryId,
                    Name = c.Category.Name
                }).ToList();
                blog.PictureDtos = _context.Pictures.Where(p => p.BlogId == blog.Id).Select(p => new PicturesDTO
                {
                    Src = p.Src
                }).ToList();
     
                
                
            }

            return response;
        }
    }
}
