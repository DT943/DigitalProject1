using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Loyalty.Application.MemberAccrualTransactions.Dtos;

namespace Loyalty.Application.MemberRedemptionTransactions.Dto
{
    public class MemberRedemptionTransactionsMapperProfile : Profile
    {
        public MemberRedemptionTransactionsMapperProfile()
        {
            CreateMap<MemberRedemptionTransactionsCreateDto, Domain.Models.MemberRedemptionTransactions>();
            CreateMap<MemberRedemptionTransactionsUpdateDto, Domain.Models.MemberRedemptionTransactions>();
            CreateMap<Domain.Models.MemberRedemptionTransactions, MemberRedemptionTransactionsGetDto>();
            CreateMap<Domain.Models.MemberTransactionRedemptionDetails, MemberTransactionRedemptionDetailsGetDto>();
        }
    }
}
