﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Features.Task.Shared;
using TaskManagerPro.Domain.Common.Enums;

namespace TaskManagerPro.Application.Features.Task.Commands.UpdateTask;

public class UpdateTaskCommand: BaseTask,IRequest<Unit>
{
    public int Id { get; set; }
}
