using ProjekatASP.Application.DataTransfer;
using ProjekatASP.Application.Queries.User;
using ProjekatASP.DataAccess.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.Queries.User
{
    public class EfGetOneUserQuery : IGetOneUserQuery
    {
        public readonly Context _context;

        public EfGetOneUserQuery(Context context)
        {
            _context = context;
        }

        public int Id => 3;

        public string Name => "Get one user";

        public UserDTO Execute(int id)
        {
            var user = _context.Users.Find(id);
            var response = new UserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email
            };
            return response;
        }
    }
}
