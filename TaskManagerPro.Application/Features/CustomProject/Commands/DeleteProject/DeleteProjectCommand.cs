﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerPro.Application.Features.CustomPrject.Commands.DeleteProject
{
    public class DeleteProjectCommand : IRequest
    {
        public int Id {set; get;}
    }
}
