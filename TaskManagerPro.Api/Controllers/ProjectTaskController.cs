using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerPro.Application.Features.Task.Commands.ChangeTaskStatus;
using TaskManagerPro.Application.Features.Task.Commands.CloseTask;
using TaskManagerPro.Application.Features.Task.Commands.CreateTask;
using TaskManagerPro.Application.Features.Task.Commands.DeleteTask;
using TaskManagerPro.Application.Features.Task.Commands.UpdateTask;
using TaskManagerPro.Application.Features.Task.Queries.GetAllTasks;
using TaskManagerPro.Application.Features.Task.Queries.GetTaskDetails;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagerPro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProjectTaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectTaskController(IMediator mediator) 
        {
            this._mediator = mediator;
        }  
        
        [HttpGet]
        public async Task<ActionResult<List<TaskDto>>> Get()
        {
            var tasks = await _mediator.Send(new GetTasksQuery());
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDetailsDto>> Get(int id)
        {
            var projectTask = await _mediator.Send(new GetTaskDetailsQuery(id));
            return Ok(projectTask);

        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateTaskCommand taskProject)
        {
            var response = await _mediator.Send(taskProject);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateTaskCommand taskProject)
        {
            await _mediator.Send(taskProject);
            return NoContent();
        }

        [HttpPut]
        [Route("CloseTask")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]

        public async Task<ActionResult> CloseTask(CloseTaskCommand taskClose)
        {
            await _mediator.Send(taskClose);
            return NoContent();
        }

        [HttpPut]
        [Route("UpdateStatus")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateStatus(ChangeTaskStatusCommand changeTaskStatus)
        {
            await _mediator.Send(changeTaskStatus);
            return NoContent(); 
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteTaskCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
