using ProjekatASP.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.Exceptions
{
    public class UnauthorizedUseCaseExceptiion : Exception
    {
        public UnauthorizedUseCaseExceptiion(IUseCase useCase, IApplicationActor actor)
        : base($"Actor with id:{actor.Id} - {actor.Identity} tried to execute {useCase.Name}.")
        {

        }
    }
}
