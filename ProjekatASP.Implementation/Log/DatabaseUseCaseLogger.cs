using Newtonsoft.Json;
using ProjekatASP.Application.Util;
using ProjekatASP.DataAccess.Configuration;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.Log
{
    public class DatabaseUseCaseLogger : IUseCaseLogger
    {
        private readonly Context _context;

        public DatabaseUseCaseLogger(Context context)
        {
            _context = context;
        }

        public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
        {
            var log = new UseCaseLog
            {
                Actor = actor.Identity,
                Data = JsonConvert.SerializeObject(useCaseData),
                Date = DateTime.UtcNow,
                UseCaseName =useCase.Name
            };
            _context.UseCaseLogs.Add(log);
            _context.SaveChanges();
        }
    }
}
