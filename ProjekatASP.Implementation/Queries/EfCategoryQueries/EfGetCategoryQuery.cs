using ProjekatASP.Application.DataTransfer;
using ProjekatASP.Application.Exceptions;
using ProjekatASP.Domain;
using ProjekatASP.Application.Queries.CategoryQuery;
using ProjekatASP.DataAccess.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.Queries
{
    public class EfGetCategoryQuery:IGetCategoryQuery
    {
        
        private readonly Context _context;

        public EfGetCategoryQuery(Context context)
        {
            _context = context;
        }

        public int Id => 10;

        public string Name => "Get one category";

        public CategoryDTO Execute(int id)
        {
            var category = _context.Categories.Find(id);

            if (category == null)
            {
                throw new EntityNotFoundException(id, typeof(Category)) ;
            }

            var result = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name
            };
            return result;
        }
    }
}
