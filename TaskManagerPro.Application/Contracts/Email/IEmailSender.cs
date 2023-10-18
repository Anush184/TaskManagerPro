using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Models.Email;

namespace TaskManagerPro.Application.Contracts.Email
{
    public interface IEmailSender
    {
        public Task<bool> SendEmail(EmailMessage email);
    }
}
