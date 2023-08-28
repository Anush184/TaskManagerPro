using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerPro.Domain.Common.Enums
{
    public enum TaskStatus
    {
        NotStarted,
        InProgress,
        Completed,
        OnHold,
        Cancelled,
        Deferred
    }
}
