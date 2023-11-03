using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Exceptions;
using TaskManagerPro.Application.Features.Task.Commands.CreateTask;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Features.CustomUser.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            this._mapper = mapper;
            this._userRepository = userRepository;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var validator = new CreateUserCommandValidator(_userRepository);
            var validatorResult = await validator.ValidateAsync(request);
            if (validatorResult.Errors.Any())
                throw new BadRequestException("Invalid User", validatorResult);


            var userToCreate = _mapper.Map<User>(request);

            await _userRepository.CreateAsync(userToCreate);

            return userToCreate.Id;
        }
    }

}
