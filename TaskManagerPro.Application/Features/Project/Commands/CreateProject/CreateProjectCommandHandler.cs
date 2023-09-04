﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Exceptions;

namespace TaskManagerPro.Application.Features.Project.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand,int>
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;

        public CreateProjectCommandHandler(IMapper mapper, IProjectRepository projectRepository)
        {
            this._mapper = mapper;
            this._projectRepository = projectRepository;
        }
        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProjectCommandValidator(_projectRepository);
            var validatorResult = validator.Validate(request);

            if (validatorResult.Errors.Any())
               throw new BadRequestException("Invalid Project", validatorResult);

            var projectToCreate = _mapper.Map<Domain.Project>(request);

            await _projectRepository.CreateAsync(projectToCreate);
            return projectToCreate.Id;


        }
    }
}