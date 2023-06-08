using ProjekatASP.Application;
using ProjekatASP.Application.DataTransfer;
using ProjekatASP.Application.Queries;
using ProjekatASP.Application.Queries.Pagination;
using ProjekatASP.DataAccess.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.Queries
{
    public class EfGetLogsQuery : IGetLogsQuery
    {
        private readonly Context context;

        public EfGetLogsQuery(Context context)
        {
            this.context = context;
        }

        public int Id => 21;

        public string Name => "Get logs by search";

        public PagedResponse<LogDTO> Execute(LogSearch search)
        {
            var query = context.UseCaseLogs.AsQueryable();
            if (!string.IsNullOrEmpty(search.UseCaseName) || !string.IsNullOrWhiteSpace(search.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName.ToLower()));
            }
            var skipcount = search.PerPage * (search.Page - 1);
            var response = new PagedResponse<LogDTO>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipcount).Take(search.PerPage).Select(x => new LogDTO
                {
                    Id = x.Id,
                    Date = x.Date,
                    UseCaseName = x.UseCaseName,
                    Data = x.Data,
                    Actor = x.Actor
                }).ToList()
            };
            return response;
        }
    }
}
