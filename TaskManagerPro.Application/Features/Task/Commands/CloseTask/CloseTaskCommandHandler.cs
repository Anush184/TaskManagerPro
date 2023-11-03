using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Email;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Exceptions;
using TaskManagerPro.Application.Models.Email;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Features.Task.Commands.CloseTask
{
    public class CloseTaskCommandHandler : IRequestHandler<CloseTaskCommand, Unit>
    {
        private readonly IProjectTaskRepository _taskRepository;
        private readonly IEmailSender _emailSender;

        public CloseTaskCommandHandler(IProjectTaskRepository taskRepository, IEmailSender emailSender) 
        {
            this._taskRepository = taskRepository;
            this._emailSender = emailSender;
        }
        public async Task<Unit> Handle(CloseTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.Id);
            if (task is null)
                throw new NotFoundException(nameof(ProjectTask), request.Id);

            task.IsClosed = true;
            var email = new EmailMessage
            {
                To = string.Empty,
                Body = $"{request.Id} Task created at {task.CreatedAt}, was closed successfully.",
                Subject = "Task Closed."
            };

            await _emailSender.SendEmail(email);
            return Unit.Value;

        }
    }
}
