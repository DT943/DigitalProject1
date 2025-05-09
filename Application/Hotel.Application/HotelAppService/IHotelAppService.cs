using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gallery.Application.FileAppservice.Dtos;
using Hotel.Application.HotelAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace Hotel.Application.HotelAppService
{
    public interface IHotelAppService : IBaseAppService<HotelGetAllDto, HotelGetDto, HotelCreateDto, HotelUpdateDto, SieveModel>
    {
        Task<FileGetDto> MakeContract(ContractCreateDto contractCreateDto);

    }
}
