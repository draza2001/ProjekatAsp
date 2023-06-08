using ProjekatASP.Application.DataTransfer;
using ProjekatASP.Application.Queries.Pagination;
using ProjekatASP.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.Queries
{
    public interface IGetLogsQuery:IQuery<LogSearch,PagedResponse<LogDTO>>
    {
    }
}
