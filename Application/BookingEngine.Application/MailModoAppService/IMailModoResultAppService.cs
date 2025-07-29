using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.MailModoAppService.Dtos;
using BookingEngine.Application.OTAUserAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace BookingEngine.Application.MailModoResultAppService
{
    public interface IMailModoResultAppService : IBaseAppService<MailModoGetDto, MailModoGetDto, MailModoCreateDto, MailModoUpdateDto, SieveModel>
    {
    }
}
