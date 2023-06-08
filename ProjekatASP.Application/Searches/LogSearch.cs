using ProjekatASP.Application.Queries.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application
{
    public class LogSearch:PagedSearch
    {
        public string UseCaseName { get; set; }
    }
}
