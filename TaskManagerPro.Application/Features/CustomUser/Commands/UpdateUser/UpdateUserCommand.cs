using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Features.CustomUser.Shared;
using TaskManagerPro.Domain.Common.Enums;

namespace TaskManagerPro.Application.Features.CustomUser.Commands.UpdateUser
{
   public class UpdateUserCommand : BaseUser,IRequest<Unit>
    {
        public int UserId { get; set; }
    }

}
