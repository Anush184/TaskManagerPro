using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Domain.Common.Enums;

namespace TaskManagerPro.Application.Features.Task.Commands.CreateTask;

public class CreateTaskCommand : IRequest<int>
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public int ProjectId { get; set; }

}
