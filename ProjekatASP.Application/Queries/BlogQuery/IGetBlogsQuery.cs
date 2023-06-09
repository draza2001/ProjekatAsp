using ProjekatASP.Application.DataTransfer;
using ProjekatASP.Application.Queries.Pagination;
using ProjekatASP.Application.Searches;
using ProjekatASP.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.Queries.BlogQuery
{
    public interface IGetBlogsQuery:IQuery <Search,PagedResponse<BlogDTO>>
    {
    }
}
