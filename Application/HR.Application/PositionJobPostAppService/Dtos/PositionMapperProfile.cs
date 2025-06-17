using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.Domain.Models;

namespace HR.Application.PositionAppService.Dtos
{
    public class PositionMapperProfile : Profile
    {
        public PositionMapperProfile()
        {
            CreateMap<PositionCreateDto, Position>();

            CreateMap<PositionUpdateDto, Position>();

            CreateMap<Position, PositionGetDto>();

            CreateMap<Position, PositionGetAllDto>();
        }
    }
}
