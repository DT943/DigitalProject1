using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingEngine.Application.OTAUserAppService;
using BookingEngine.Application.OTAUserAppService.Dtos;
using BookingEngine.Application.OTAUserAppService.Validations;
using BookingEngine.Data.DbContext;
using BookingEngine.Data.Migrations;
using Infrastructure.Application;
using Infrastructure.Application.Exceptions;
using Infrastructure.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace BookingEngine.Application.OTAUserService
{
    public class OTAUserAppService : BaseAppService<BookingEngineDbContext, Domain.Models.OTAUser, OTAUserGetDto, OTAUserGetDto, OTAUserCreateDto, OTAUserUpdateDto, SieveModel>, IOTAUserAppService
    {
        private readonly IEncryptionAppService _encryptionAppService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;


        public OTAUserAppService(BookingEngineDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, OTAUserValidator validations, IHttpContextAccessor httpContextAccessor, IEncryptionAppService encryptionAppService) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _encryptionAppService = encryptionAppService ?? throw new ArgumentNullException(nameof(encryptionAppService));

        }
        protected override Domain.Models.OTAUser BeforCreate(OTAUserCreateDto create)
        {
            // Map normally
            Domain.Models.OTAUser createdEntity = _mapper.Map<Domain.Models.OTAUser>(create);

            // Add the generated code
            createdEntity.Code = typeof(Domain.Models.OTAUser).Name + "_" + Guid.NewGuid().ToString();

            // Encrypt the password here instead of mapper resolver
            if (!string.IsNullOrEmpty(create.Password))
            {
                createdEntity.EncryptedPassword = _encryptionAppService.Encrypt(create.Password);
            }

            // Set audit fields
            if (createdEntity is BasicEntityWithAuditInfo auditEntity)
            {
                auditEntity.CreatedBy = _httpContextAccessor.HttpContext?.User.FindFirst("userCode")?.Value;
                auditEntity.CreatedDate = DateTime.Now;

            }

            return createdEntity;
        }


        protected override Domain.Models.OTAUser BeforUpdate(OTAUserUpdateDto update, Domain.Models.OTAUser entity)
        {
            // Encrypt the password if it is provided in the update DTO
            if (!string.IsNullOrEmpty(update.Password))
            {
                entity.EncryptedPassword = _encryptionAppService.Encrypt(update.Password);
            }

            // Update audit fields
            if (entity is BasicEntityWithAuditInfo auditEntity)
            {
                auditEntity.ModifiedBy = _httpContextAccessor.HttpContext?.User.FindFirst("userCode")?.Value;
                auditEntity.ModifiedDate = DateTime.Now;
            }

            entity = _mapper.Map(update, entity);

            return entity;
        }


        public async Task<OTAUserGetDto> GetByPOS(string pos)
        {
            var entity = await _serviceDbContext.OTAUsers
                .Include(x => x.POS)
                .FirstOrDefaultAsync(x => x.POS.POSCode == pos);

            return _mapper.Map<OTAUserGetDto>(entity);
        }
        public async Task<OTAUserGetDto> GetByPOSId(int posId)
        {
            var entity = await _serviceDbContext.OTAUsers
                .Include(x => x.POS)
                .FirstOrDefaultAsync(x => x.POSId == posId);

            return _mapper.Map<OTAUserGetDto>(entity);
        }


        protected override IQueryable<Domain.Models.OTAUser> QueryExcuter(SieveModel input)
        {

            return base.QueryExcuter(input)
              .Include(x => x.POS);
        }

    }



}
