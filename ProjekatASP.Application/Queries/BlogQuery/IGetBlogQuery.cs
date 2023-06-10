using ProjekatASP.Application.DataTransfer;
using ProjekatASP.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.Queries.BlogQuery
{
    public interface IGetBlogQuery : IQuery<int,BlogDTO>
    {
    }
}
