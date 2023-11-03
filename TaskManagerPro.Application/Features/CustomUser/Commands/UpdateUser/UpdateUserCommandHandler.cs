using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Exceptions;
using TaskManagerPro.Application.Features.CustomProject.Commands.UpdateProject;
using TaskManagerPro.Domain.Entities;

namespace TaskManagerPro.Application.Features.CustomUser.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateUserCommandValidator(_userRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Any())
                throw new BadRequestException("Invalid User", validatorResult);

            var userToUpdate = _mapper.Map<User>(request);
            if (userToUpdate == null)
                throw new NotFoundException(nameof(User), request.UserId);

            await _userRepository.UpdateAsync(userToUpdate);
            return Unit.Value;
        }
    }

}
