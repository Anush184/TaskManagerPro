using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerPro.Application.Features.Task.Queries.GetTaskDetails
{
    public record GetTaskDetailsQuery(int Id) : IRequest<TaskDetailsDto>;
    
}
