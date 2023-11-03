using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagerPro.Application.Features.CustomComment.Commands.CreateComment;
using TaskManagerPro.Application.Features.CustomComment.Commands.DeleteComment;
using TaskManagerPro.Application.Features.CustomComment.Commands.UpdateComment;
using TaskManagerPro.Application.Features.CustomComment.Queries.GetAllComments;
using TaskManagerPro.Application.Features.CustomComment.Queries.GetCommentDetails;
using TaskManagerPro.Application.Features.CustomUser.Commands.DeleteUser;
using TaskManagerPro.Application.Features.CustomUser.Queries.GetAllUsers;
using TaskManagerPro.Application.Features.CustomUser.Queries.GetUserDetails;
using TaskManagerPro.Domain.Entities;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagerPro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<CommentDto>>> Get()
        {
            var comments = await _mediator.Send(new GetCommentsQuery());
            return Ok(comments);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDto>> Get(int id)
        {
            var comment = await _mediator.Send(new GetCommentDetailsQuery(id));
            return Ok(comment);

        }

        
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateCommentCommand comment)
        {
            var response = await _mediator.Send(comment);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateCommentCommand comment)
        {
            await _mediator.Send(comment);
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCommentCommand { CommentId = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
