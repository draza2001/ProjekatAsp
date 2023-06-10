using Microsoft.AspNetCore.Mvc;
using ProjekatASP.Application;
using ProjekatASP.Application.Commands.Blogcommands;
using ProjekatASP.Application.DataTransfer;
using ProjekatASP.Application.Queries.BlogQuery;
using ProjekatASP.Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public BlogController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/<BlogController>
        [HttpGet]
        public IActionResult Get([FromQuery] Search search,[FromServices] IGetBlogsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET api/<BlogController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,[FromServices] IGetBlogQuery command)
        {
            return Ok(executor.ExecuteQuery(command,id));
        }

        // POST api/<BlogController>
        [HttpPost]
        public IActionResult Post([FromBody] BlogDTO dto,[FromServices]ICreateBlogCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // PUT api/<BlogController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BlogDTO dto,[FromServices] IUpdateBlogCommand command)
        {
            executor.ExecuteCommandUpdate(command, dto, id);
                return NoContent();
        }

        // DELETE api/<BlogController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteBlogCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
