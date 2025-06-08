using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application;
using Loyalty.Application.ComplaintsAppService.Dtos;
using Loyalty.Application.MemberAccrualTransactions.Dtos;
using Sieve.Models;

namespace Loyalty.Application.ComplaintsAppService
{
    public interface IComplaintsAppService : IBaseAppService<ComplaintsGetDto, ComplaintsGetDto, ComplaintsCreateDto, ComplaintsUpdateDto, SieveModel>
    {
    }
}
