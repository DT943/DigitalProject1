using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingEngine.Application.WrappingAppService.IEmailAppService
{
	public interface IEmailManager
	{
		Task SendEmailAsync(object payload);
	}
}

