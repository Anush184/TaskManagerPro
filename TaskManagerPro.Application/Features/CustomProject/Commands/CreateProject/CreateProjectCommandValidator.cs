using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Features.CustomProject.Shared;

namespace TaskManagerPro.Application.Features.CustomProject.Commands.CreateProject;

public class CreateProjectCommandValidator: AbstractValidator<CreateProjectCommand>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUserRepository _userRepository;

    public CreateProjectCommandValidator(IProjectRepository projectRepository, IUserRepository userRepository)
    {
        this._projectRepository = projectRepository;
        this._userRepository = userRepository;
        Include(new BaseProjectValidator(_projectRepository, _userRepository));
    }
}
