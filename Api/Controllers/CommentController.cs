using Microsoft.AspNetCore.Mvc;
using ProjekatASP.Application;
using ProjekatASP.Application.Commands.CommentCommands;
using ProjekatASP.Application.DataTransfer;
using ProjekatASP.Application.Queries.CommentQuery;
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
    public class CommentController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public CommentController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }

        // GET: api/<CommentController>
        [HttpGet("{id}")]
        public IActionResult Get(int id,[FromServices] IGetCommentsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }




        // POST api/<CommentController>
        [HttpPost]
        public IActionResult Post([FromBody] CommentDTO dto,[FromServices] ICreateCommentCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CommentDTO dto,[FromServices]IUpdateCommentCommand command)
        {
            executor.ExecuteCommandUpdate(command,dto, id);
            return NoContent();
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteCommentCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
