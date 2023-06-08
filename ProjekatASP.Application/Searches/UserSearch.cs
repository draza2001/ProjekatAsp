using ProjekatASP.Application.Queries.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.Searches
{
    public class UserSearch:PagedSearch
    {
        public string Username { get; set; }
    }
}
