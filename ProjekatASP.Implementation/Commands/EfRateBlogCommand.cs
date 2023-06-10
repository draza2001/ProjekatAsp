using ProjekatASP.Application.Commands;
using ProjekatASP.Application.DataTransfer;
using ProjekatASP.Application.Util;
using ProjekatASP.DataAccess.Configuration;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.Commands
{
    public class EfRateBlogCommand: IRateBlog
    {
        private readonly Context context;
        private readonly IApplicationActor actor;

        public EfRateBlogCommand(Context context, IApplicationActor actor)
        {
            this.context = context;
            this.actor = actor;
        }

        public int Id => 20;

        public string Name => "Rate blog";

        public void Execute(RateDTO request, int id)
        {
            var userRateBlog = context.Rates.Where(x => x.BlogId == request.BlogId).Select(x => x.UserId);

            if (request.RateNumber > 5 || request.RateNumber<0)
            {
                throw new ArgumentException("Number must be between 1 and 5");
            }
            if (userRateBlog.Contains(actor.Id))
            {
                throw new ArgumentException("You already vote");
            }
            var rate = new Rate
            {
                RateNumber = request.RateNumber,
                UserId=actor.Id,
                BlogId=id
            };
            context.Rates.Add(rate);
            context.SaveChanges();
        }
    }
}
