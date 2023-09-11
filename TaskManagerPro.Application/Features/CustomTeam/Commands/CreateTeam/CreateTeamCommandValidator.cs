using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Features.Task.Commands.CreateTask;

namespace TaskManagerPro.Application.Features.CustomTeam.Commands.CreateTeam
{
    public class CreateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
    {
        private readonly ITeamRepository _teamRepository;

        public CreateTeamCommandValidator(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
            RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters.");

            RuleFor(p => p.MemberIds)
                .NotNull();

            RuleFor(p => p)
                .MustAsync(TeamNameUnique)
                .WithMessage("Team Name already exists.");
        }
        private Task<bool> TeamNameUnique(CreateTeamCommand command, CancellationToken token)
        {
            return _teamRepository.IsTeamNameUnique(command.Name);
        }
    }
}
