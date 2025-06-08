using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Loyalty.Application.MemberAccrualTransactions.Dtos;

namespace Loyalty.Application.ComplaintsAppService.Dtos
{
    public class ComplaintsMapperProfile : Profile
    {
        public ComplaintsMapperProfile()
        {
            CreateMap<ComplaintsCreateDto, Domain.Models.Complaints>();
            CreateMap<ComplaintsUpdateDto, Domain.Models.Complaints>();
            CreateMap<Domain.Models.Complaints, ComplaintsGetDto>();


        }
    }
}