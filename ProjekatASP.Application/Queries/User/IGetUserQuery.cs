using ProjekatASP.Application.DataTransfer;
using ProjekatASP.Application.Queries.Pagination;
using ProjekatASP.Application.Searches;
using ProjekatASP.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.Queries.User
{
    public interface IGetUserQuery :IQuery<UserSearch , PagedResponse<UserDTO>>
    {
    }
}
