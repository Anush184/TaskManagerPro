using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Features.Task.Queries.GetTaskDetails;

namespace TaskManagerPro.Application.Features.CustomUser.Queries.GetUserDetails;

public record GetUserDetailsQuery(int Id) : IRequest<UserDetailsDto>;
