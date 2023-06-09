using ProjekatASP.Application.Queries.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.Searches
{
    public class Search : PagedSearch
    {
        public string Name { get; set; }
    }
}
