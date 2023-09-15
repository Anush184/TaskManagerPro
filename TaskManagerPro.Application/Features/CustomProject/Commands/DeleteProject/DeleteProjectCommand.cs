using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerPro.Application.Features.CustomProject.Commands.DeleteProject
{
    public class DeleteProjectCommand : IRequest<Unit>
    {
        public int Id {set; get;}
    }
}
