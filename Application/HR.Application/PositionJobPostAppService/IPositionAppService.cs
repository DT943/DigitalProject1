using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Application.PositionAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace HR.Application.PositionAppService
{
    public interface IPositionAppService : IBaseAppService<PositionGetAllDto, PositionGetDto, PositionCreateDto, PositionUpdateDto, SieveModel>
    {
    }
}
