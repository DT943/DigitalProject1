using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingEngine.Domain.Models;

namespace BookingEngine.Application.AuditAppService.Dtos
{
    public class SearchRequestMapperProfile : Profile
    {
        public SearchRequestMapperProfile()
        {

            // For Create
            CreateMap<SearchRequestCreateDto, SearchRequest>();


            // For Update
            CreateMap<SearchRequestUpdateDto, SearchRequest>();


            // For Get (Optional for now)
            CreateMap<SearchRequest, SearchRequestGetDto>();

        }
    }
}
