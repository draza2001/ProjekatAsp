using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.Util
{
    public interface IUseCaseLogger
    {
        void Log(IUseCase useCase, IApplicationActor actor, object useCaseData);
    }
}
