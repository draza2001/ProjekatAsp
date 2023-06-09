using ProjekatASP.Application.DataTransfer;
using ProjekatASP.Application.Queries.CategoryQuery;
using ProjekatASP.Application.Queries.Pagination;
using ProjekatASP.Application.Searches;
using ProjekatASP.DataAccess.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.Queries
{
    public class EfGetCategoriesQuery : IGetCategoriesQuery
    {
        private readonly Context _context;

        public EfGetCategoriesQuery(Context context)
        {
            _context = context;
        }

        public int Id => 9;

        public string Name => "Category search";

        public PagedResponse<CategoryDTO> Execute(Search search)
        {
            var query = _context.Categories.AsQueryable();

            if(!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name)) 
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            query = query.Where(x => x.IsActive == true);

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<CategoryDTO>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new CategoryDTO
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()
            };
            return response;

        }
    }
}
