using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagerPro.Application.Features.CustomPrject.Commands.DeleteProject;
using TaskManagerPro.Application.Features.CustomProject.Commands.CreateProject;
using TaskManagerPro.Application.Features.CustomProject.Commands.UpdateProject;
using TaskManagerPro.Application.Features.CustomProject.Queries.GetAllProjects;
using TaskManagerPro.Application.Features.CustomProject.Queries.GetProjectDetails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagerPro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        
        [HttpGet]
        public async Task<List<ProjectDto>> Get()
        {
            var projects = await _mediator.Send(new GetProjectsQuery());
            return projects;
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDetailsDto>> Get(int id)
        {
            var project = _mediator.Send(new GetProjectDetailsQuery(id));
            return Ok(project);
        }

        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateProjectCommand project)
        {
            var response = await _mediator.Send(project);
            return CreatedAtAction(nameof(Get), new { id = response});
        }

        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateProjectCommand project)
        {
            await _mediator.Send(project);
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
           var command = new DeleteProjectCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
