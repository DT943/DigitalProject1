﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application
{
    public interface IEmailAppService
    {
        Task SendEmailAsync(string email, string subject, string password, string userName);

    }
}
