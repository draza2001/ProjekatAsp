using ProjekatASP.Application.DataTransfer;
using ProjekatASP.Application.Queries.Pagination;
using ProjekatASP.Application.Queries.User;
using ProjekatASP.Application.Searches;
using ProjekatASP.DataAccess.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.Queries
{
    public class EfGetUsersQuery : IGetUserQuery
    {
        private readonly Context context;
        public int Id => 14;

        public string Name => "Get users";

        public PagedResponse<UserDTO> Execute(UserSearch search)
        {
            var query = context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(search.Username) || !string.IsNullOrWhiteSpace(search.Username))
            {
                query = query.Where(x => x.UserName.ToLower().Contains(search.Username.ToLower()));
            }
            query = query.Where(x => x.IsActive == true);
            var skipCount = search.PerPage * (search.Page - 1);
            var response = new PagedResponse<UserDTO>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new UserDTO
                {
                    FirstName = x.FirstName,
                    LstName = x.LastName,
                    UserName = x.UserName,
                    Email = x.Email
                }).ToList()
            };
            return response;
        }
    }
}
