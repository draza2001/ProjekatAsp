using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjekatASP.Application;
using ProjekatASP.Application.Commands;
using ProjekatASP.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        public RegisterController(UseCaseExecutor executor)
        {
            _executor = executor;
        }
        [HttpPost]
        public void Post([FromBody] RegisterDTO dto,[FromServices] IRegisterUserCommand command)
        {
            _executor.ExecuteCommand(command, dto);
        }
    }
}
