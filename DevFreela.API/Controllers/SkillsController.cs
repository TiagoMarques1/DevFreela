using DevFreela.Application.Queries.GetAllSkills;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public SkillsController(IMediator mediator)
        {
            _mediatR = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllSkillsQuery();
            var skills = await _mediatR.Send(query);

            return Ok(skills);
        }
    }
}
