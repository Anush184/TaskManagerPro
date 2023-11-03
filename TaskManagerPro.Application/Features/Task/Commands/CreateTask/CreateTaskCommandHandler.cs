using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Email;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Exceptions;
using TaskManagerPro.Application.Models.Email;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Features.Task.Commands.CreateTask;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IProjectTaskRepository _taskRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IEmailSender _emailSender;

    public CreateTaskCommandHandler(IMapper mapper, 
        IProjectTaskRepository taskRepository, IProjectRepository projectRepository, IEmailSender emailSender)
    {
        this._mapper = mapper;
        this._taskRepository = taskRepository;
        _projectRepository = projectRepository;
        this._emailSender = emailSender;
    }
    public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        
        var validator = new CreateTaskCommandValidator(_projectRepository, _taskRepository);
        var validatorResult = await validator.ValidateAsync(request);
        if (validatorResult.Errors.Any())
            throw new BadRequestException("Invalid Task", validatorResult);

        // Get Project
        // Assign tasks

        var taskToCreate = _mapper.Map<ProjectTask>(request);

        await _taskRepository.CreateAsync(taskToCreate);

        // send confirmation email
        var email = new EmailMessage
        {
            To = string.Empty,
            Body = $"{request.AssigneeId} team members task has been submitted successfully.",
            Subject = "Task Submitted."
        };

        await _emailSender.SendEmail(email);
        return taskToCreate.Id;
    }
}
