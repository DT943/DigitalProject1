using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Application.ApplicationAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;


namespace HR.Application.ApplicationAppService
{
    public interface IApplicationAppService: IBaseAppService<ApplicationGetAllDto, ApplicationGetDto, ApplicationCreateDto, ApplicationUpdateDto, SieveModel>
    {
    }
}
