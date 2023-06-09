using ProjekatASP.Application.DataTransfer;
using ProjekatASP.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.Commands.Usercommands
{
    public interface IUpdateUserCommand:ICommandUpdate<UserDTO,int>
    {
    }
}
