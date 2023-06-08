using Microsoft.AspNetCore.Mvc;
using ProjekatASP.Application;
using ProjekatASP.Application.Queries;
using ProjekatASP.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        
        private readonly UseCaseExecutor _executor;
   

       
        public LogController(IApplicationActor actor, UseCaseExecutor executor)
        {
            
            _executor = executor;
        }
        // GET api/<LogController>
        [HttpGet]

        public IActionResult Get([FromQuery] LogSearch search,[FromServices] IGetLogsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }


    }
}
