using ProjekatASP.Application.Exceptions;
using ProjekatASP.Application.Util;
using System;
using System.Linq;

namespace ProjekatASP.Application
{
    public class UseCaseExecutor
    {
        private readonly IApplicationActor actor;
        private readonly IUseCaseLogger logger;

        public UseCaseExecutor(IApplicationActor actor, IUseCaseLogger logger)
        {
            this.actor = actor;
            this.logger = logger;
        }

        public void ExecuteCommand<TRequest>(ICommand<TRequest> command,TRequest request)
        {
            logger.Log(command, actor, request);
            if (!actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedUseCaseExceptiion(command, actor);
            }
            command.Execute(request);
        }

        public TResult ExecuteQuery<TSearch, TResult>(IQuery<TSearch, TResult> query,TSearch search)
        {
            logger.Log(query, actor, search);
            if (!actor.AllowedUseCases.Contains(query.Id))
            {
                throw new UnauthorizedUseCaseExceptiion(query, actor);
            }
            return query.Execute(search);
        }
        public void ExecuteCommandUpdate<TRequest>(ICommandUpdate<TRequest,int>command,TRequest request,int id)
        {
            logger.Log(command, actor, request);
            if (!actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedUseCaseExceptiion(command, actor);
            }
            command.Execute(request, id);
        }
        public void ExecuteCommandComment<TRequest>(ICommandWithInt<TRequest, int> command, TRequest request, int id)
        {
            logger.Log(command, actor, request);
            if (!actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedUseCaseExceptiion(command, actor);
            }
            command.Execute(request, id);
        }
    }
}
