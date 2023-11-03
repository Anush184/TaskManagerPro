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

namespace TaskManagerPro.Application.Features.Task.Commands.ChangeTaskStatus
{
    public class ChangeTaskStatusCommandHandler : IRequestHandler<ChangeTaskStatusCommand, Unit>
    {
        private readonly IProjectTaskRepository _taskRepository;
        private readonly IEmailSender _emailSender;

        public ChangeTaskStatusCommandHandler(IProjectTaskRepository taskRepository, IEmailSender emailSender) 
        {
            this._taskRepository = taskRepository;
            this._emailSender = emailSender;
        }
        public async Task<Unit> Handle(ChangeTaskStatusCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.Id);
            if (task is null)
                throw new NotFoundException(nameof(ProjectTask), request.Id);
            task.Status = request.Status;
            await _taskRepository.UpdateAsync(task);

            // if task status is Resolved it automatically will be assign to manager.

            var email = new EmailMessage
            {
                To = string.Empty,
                Body = $"{task.Id} task's '{task.Status}' status has been updated.",
                Subject = "Task Status Updated."
            };

            await _emailSender.SendEmail(email);
            return Unit.Value;  
        }
    }
}
