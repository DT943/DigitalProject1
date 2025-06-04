using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Application;
using Infrastructure.Application.Exceptions;
using Infrastructure.Domain.Models;
using Loyalty.Application.MemberTierDetailsAppService.Dto;
using Loyalty.Application.MemberTierDetailsAppService.Validations;
using Loyalty.Data.DbContext;
using Loyalty.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using Sieve.Models;
using Sieve.Services;

namespace Loyalty.Application.MemberTierDetailsAppService
{
    public class MemberTierDetailsAppService : BaseAppService<LoyaltyDbContext, Domain.Models.MemberTierDetails, MemberTierDetailsGetDto, MemberTierDetailsGetDto, MemberTierDetailsCreateDto, MemberTierDetailsUpdateDto, SieveModel>, IMemberTierDetailsAppService
    {
        public MemberTierDetailsAppService(LoyaltyDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, MemberTierDetailsValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }

        protected override MemberTierDetails BeforCreate(MemberTierDetailsCreateDto create)
        {
            MemberTierDetails createdEntity = _mapper.Map<MemberTierDetails>(create);
            createdEntity.Code = typeof(MemberTierDetails).Name + "_" + Guid.NewGuid().ToString();
            createdEntity.QrCode = GenerateQrCode(createdEntity.Code);
            return createdEntity;
        }

        static string GenerateQrCode(string text)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCoder.Base64QRCode(qrCodeData).GetGraphic(20);
            return qrCode;

        }

    }
}
