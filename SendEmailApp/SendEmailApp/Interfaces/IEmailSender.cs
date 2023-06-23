using SendEmailApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendEmailApp.Interfaces
{
    public interface IEmailSender
    {
       // void SendEmail(Message message);
        Task SendEmailAsync(Message message, string username);
    }
}
