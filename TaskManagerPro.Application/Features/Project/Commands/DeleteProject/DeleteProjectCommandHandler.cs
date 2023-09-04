using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Exceptions;

namespace TaskManagerPro.Application.Features.Project.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler: IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;

        public DeleteProjectCommandHandler(IProjectRepository projectRepository)
        {
            this._projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var projectToDelete = await _projectRepository.GetByIdAsync(request.Id);
            if (projectToDelete == null)
                throw new NotFoundException(nameof(Project), request.Id);

            await _projectRepository.DeleteAsync(projectToDelete);
            return Unit.Value;
        }
    }
}
