using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Queries.GetByIdUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // api/users/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdUserQuery(id);
            var user = await _mediator.Send(query);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // api/users
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand query)
        {
            var id = await _mediator.Send(query);

            return CreatedAtAction(nameof(GetById), new { id = id }, query);
        }

        // api/users/1/login
        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginInputModel login)
        {
            // TODO: Para Módulo de Autenticação e Autorização

            return NoContent();
        }
    }
}
