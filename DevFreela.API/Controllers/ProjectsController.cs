using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetAllProject;
using DevFreela.Application.Queries.GetByIdProject;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public ProjectsController(IMediator mediator)
        {
            _mediatR = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommands command)
        {
            if (command.Title.Length > 50)
            {
                return BadRequest();
            }

            var id = await _mediatR.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        // api/projects/1/comments POST
        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
        {
            await _mediatR.Send(command);

            return NoContent();
        }

        // api/projects/2
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateProjectCommand command)
        {
            if (command.Description.Length > 200)
            {
                return BadRequest();
            }

            await _mediatR.Send(command);

            return NoContent();
        }

        // api/projects/1/start
        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(int id)
        {
            var command = new StartProjecCommand(id);
            await _mediatR.Send(command);

            return NoContent();
        }

        // api/projects/1/finish
        [HttpPut("{id}/finish")]
        public async Task<IActionResult> Finish(int id)
        {
            var command = new FinishProjectCommand(id);
            await _mediatR.Send(command);

            return NoContent();
        }

        // api/projects?query=net core
        [HttpGet]
        public async Task<IActionResult> GetAll(string query)
        {
            var getAllProjectsQuery = new GetAllProjectQuery(query);
            var projects = await _mediatR.Send(getAllProjectsQuery);

            return Ok(projects);
        }

        // api/projects/2
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdProjectQuery(id);
            var project = await _mediatR.Send(query);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // api/projects/3 DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand(id);

            await _mediatR.Send(command);

            return NoContent();
        }
    }
}
