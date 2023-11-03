using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Common.Enums;

namespace TaskManagerPro.Application.Features.Task.Commands.ChangeTaskStatus
{
    public class ChangeTaskStatusCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public StatusOfTask Status { get; set; }
    }
}
