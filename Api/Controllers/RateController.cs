using Microsoft.AspNetCore.Mvc;
using ProjekatASP.Application;
using ProjekatASP.Application.Commands;
using ProjekatASP.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {

        private readonly UseCaseExecutor _executor;

        public RateController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // POST api/<RateController>
        [HttpPost("blog/{id}")]
        public IActionResult Post(int id,[FromBody] RateDTO dto,[FromServices] IRateBlog command)
        {
            _executor.ExecuteCommandComment(command, dto, id);
            return NoContent();
        }


    }
}
