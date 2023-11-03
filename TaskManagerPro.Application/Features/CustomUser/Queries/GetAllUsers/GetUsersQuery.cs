using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Features.Task.Queries.GetAllTasks;

namespace TaskManagerPro.Application.Features.CustomUser.Queries.GetAllUsers;

public record GetUsersQuery : IRequest<List<UserDto>>;
