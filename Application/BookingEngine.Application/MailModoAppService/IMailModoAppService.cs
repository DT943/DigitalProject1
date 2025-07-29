using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingEngine.Application.MailModoAppService
{
    public interface IMailModoAppService
    {
        Task SendMailmodoEmail(
             string recipientEmail,
             Dictionary<string, string> dataVariables,
             string CampainName,
             Dictionary<string, string>? campaignDataVariables = null, 
             string? subject = null,
             string? replyTo = null,
             string? fromName = null,
             string? addToList = null);

    }
}
