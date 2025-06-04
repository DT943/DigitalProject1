using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Loyalty.Application.MemberAddressDetailsAppService.Dtos;

namespace Loyalty.Application.MemberAccrualTransactions.Dtos
{
    public class MemberAccrualTransactionsMapperProfile : Profile
    {
        public MemberAccrualTransactionsMapperProfile()
        {
            CreateMap<MemberAccrualTransactionsCreateDto, Domain.Models.MemberAccrualTransactions>();
            CreateMap<MemberAccrualTransactionsUpdateDto, Domain.Models.MemberAccrualTransactions>();
            CreateMap<Domain.Models.MemberAccrualTransactions, MemberAccrualTransactionsGetDto>();


        }
    }
}