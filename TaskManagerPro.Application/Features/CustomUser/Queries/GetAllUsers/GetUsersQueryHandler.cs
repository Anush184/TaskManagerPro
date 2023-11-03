using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Logging;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Application.Features.Task.Queries.GetAllTasks;

namespace TaskManagerPro.Application.Features.CustomUser.Queries.GetAllUsers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserDto>>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IAppLogger<GetUsersQueryHandler> _logger;
    public GetUsersQueryHandler(IMapper mapper, IUserRepository userRepository, IAppLogger<GetUsersQueryHandler> logger)
    {
        this._mapper = mapper;
        this._userRepository = userRepository;
        this._logger = logger;
    }
    public async Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAsync();
        var data = _mapper.Map<List<UserDto>>(users);
        _logger.LogInformation("Users were retrieved successfully.");
        return data;
    }
}
