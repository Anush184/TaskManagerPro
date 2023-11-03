using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Email;
using TaskManagerPro.Application.Contracts.Logging;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Exceptions;
using TaskManagerPro.Application.Models.Email;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Features.Task.Commands.UpdateTask;

public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IProjectTaskRepository _taskRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IAppLogger<UpdateTaskCommandHandler> _logger;
    private readonly IEmailSender _emailSender;

    public UpdateTaskCommandHandler(IMapper mapper, IProjectTaskRepository taskRepository,
        IProjectRepository projectRepository, IAppLogger<UpdateTaskCommandHandler> logger, IEmailSender emailSender)
    {
        this._mapper = mapper;
        this._taskRepository = taskRepository;
        this._projectRepository = projectRepository;
        this._logger = logger;
        this._emailSender = emailSender;
    }
    public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdAsync(request.Id);
        if (task is null)
            throw new NotFoundException(nameof(ProjectTask), request.Id);

        var validator = new UpdateTaskCommandValidator(_taskRepository, _projectRepository);
        var validationResult = validator.ValidateAsync(request);
        if(validationResult.Result.Errors.Any())
        { 
            _logger.LogWorning("Validation errors in update request for {0} - {1}", nameof(ProjectTask), request.Id);
            throw new BadRequestException("Invalid Task", validationResult.Result);
        }

        _mapper.Map(request, task);

        await _taskRepository.UpdateAsync(task);

        try
        {
            var email = new EmailMessage
            {
                To = string.Empty,/* Get email from team member record */
                Body = $"{request.AssigneeId} team member {request.Id} task for {request.ProjectId} project " +
                $"has been updated successfully.",
                Subject = "Task Updated."
            };

            await _emailSender.SendEmail(email);
        }
        catch(Exception ex)
        {
            _logger.LogWorning(ex.Message);
        }

        return Unit.Value;
         
    }
}
