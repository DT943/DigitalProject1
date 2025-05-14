using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.Application;
using AutoMapper;
using B2B.Application.TravelAgentApplicationAppService;
using B2B.Application.TravelAgentApplicationAppService.Dto;
using B2B.Application.TravelAgentEmployeeAppService.Dto;
using B2B.Application.TravelAgentOffice.Dto;
using B2B.Application.TravelAgentOffice.Validations;
using B2B.Data.DbContext;
using FluentValidation;
using Infrastructure.Application;
using Infrastructure.Application.Exceptions;
using Infrastructure.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace B2B.Application.TravelAgentOffice
{
    public class TravelAgentOfficeAppService : BaseAppService<B2BDbContext, Domain.Models.TravelAgentOffice, TravelAgentOfficeGetAllDto, TravelAgentOfficeGetDto, TravelAgentOfficeCreateDto, TravelAgentOfficeUpdateDto, SieveModel>, ITravelAgentOfficeAppService
    {
        ITravelAgentOfficeAppService _appService;
        ITravelAgentApplicationAppService _travelAgentApplicationAppServiceAppService;
        TravelAgentOfficeValidator _validations;
        IAuthenticationAppService _authenticationAppService;
        public TravelAgentOfficeAppService(B2BDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, TravelAgentOfficeValidator validations, IHttpContextAccessor httpContextAccessor, ITravelAgentApplicationAppService travelAgentApplicationAppServiceAppService, IAuthenticationAppService authenticationAppService) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _authenticationAppService = authenticationAppService;
            _travelAgentApplicationAppServiceAppService = travelAgentApplicationAppServiceAppService;
            _validations = validations;
        }
        public async Task<ActionResult<TravelAgentOfficeGetDto>> Approve(TravelAgentProcessApproveDto travelAgentProcessApproveDto)
        {
            TravelAgentApplicationGetDto travelAgentApplicationDto = await _travelAgentApplicationAppServiceAppService.Get(travelAgentProcessApproveDto.ApplicationId);


            TravelAgentOfficeCreateDto travelAgentOfficeCreateDto = new TravelAgentOfficeCreateDto();
            travelAgentOfficeCreateDto.FirstName = travelAgentApplicationDto.FirstName;
            travelAgentOfficeCreateDto.LastName = travelAgentApplicationDto.LastName;
            travelAgentOfficeCreateDto.FirstEmail = travelAgentApplicationDto.Email;
            travelAgentOfficeCreateDto.POS = travelAgentApplicationDto.POS;
            travelAgentOfficeCreateDto.AccellAeroUserName = travelAgentApplicationDto.AccelAeroUserName;
            travelAgentOfficeCreateDto.TravelAgentNameISA = travelAgentProcessApproveDto.ISAName;
            travelAgentOfficeCreateDto.AgencyName = travelAgentApplicationDto.TravelAgencyName;
            travelAgentOfficeCreateDto.Governate = "Governate";

            travelAgentOfficeCreateDto.TravelAgentPOSs = travelAgentProcessApproveDto.travelAgentPOSCreateDto;

            travelAgentOfficeCreateDto.TravelAgentEmployees = new List<TravelAgentEmployeeCreateDto>();



            foreach (var item in travelAgentApplicationDto.Employees)
            {

                travelAgentOfficeCreateDto.TravelAgentEmployees.Add(new TravelAgentEmployeeCreateDto
                {

                    EmployeeEmail = item.EmployeeEmail,
                    EmployeeFirstName = item.EmployeeFirstName,
                    EmployeeLastName = item.EmployeeLastName,
                    PhoneNumber = item.PhoneNumber

                });
            }

            var validationResult = await _validations.ValidateAsync(travelAgentOfficeCreateDto, options => options.IncludeRuleSets("create", "default"));
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            travelAgentOfficeCreateDto.TravelAgentEmployees = new List<TravelAgentEmployeeCreateDto>();



            var result = await _authenticationAppService.AddB2BUserAsync(new Authentication.Application.Dtos.AddUserDto
            {
                FirstName = travelAgentApplicationDto.FirstName,
                LastName = travelAgentApplicationDto.LastName,
                Email = travelAgentApplicationDto.Email
            });

            foreach (var item in travelAgentApplicationDto.Employees)
            {
                var employeeResult = await _authenticationAppService.AddB2BUserAsync(new Authentication.Application.Dtos.AddUserDto
                {
                    FirstName = item.EmployeeFirstName,
                    LastName = item.EmployeeLastName,
                    Email = item.EmployeeEmail
                });

                travelAgentOfficeCreateDto.TravelAgentEmployees.Add(new TravelAgentEmployeeCreateDto
                {

                    EmployeeEmail = item.EmployeeEmail,
                    EmployeeFirstName = item.EmployeeFirstName,
                    EmployeeLastName = item.EmployeeLastName,
                    PhoneNumber = item.PhoneNumber,
                    UserCode = employeeResult.Code,
                    ManagerCode = result.Code,

                });
            }

            return await this.ApprovalCreate(travelAgentOfficeCreateDto);
        }


        public  async Task<TravelAgentOfficeGetDto> ApprovalCreate(TravelAgentOfficeCreateDto create)
        { 
            var entity = BeforCreate(create);
            var result = await _serviceDbContext.Set<Domain.Models.TravelAgentOffice>().AddAsync(entity);
            try
            {
                await _serviceDbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
            }
            return await Get(result.Entity.Id);
        }

        protected override Domain.Models.TravelAgentOffice BeforCreate(TravelAgentOfficeCreateDto create)
        {
            Domain.Models.TravelAgentOffice createdEntity = _mapper.Map<Domain.Models.TravelAgentOffice>(create);
            createdEntity.Code = typeof(Domain.Models.TravelAgentOffice).Name + "_" + Guid.NewGuid().ToString();
            if (createdEntity is BasicEntityWithAuditInfo)
            {
                (createdEntity as BasicEntityWithAuditInfo).CreatedBy = _httpContextAccessor.HttpContext?.User.FindFirst("userCode")?.Value;
                (createdEntity as BasicEntityWithAuditInfo).CreatedDate = DateTime.Now;
            }

            foreach (var item in createdEntity.TravelAgentEmployees)
            {
                item.Code = typeof(Domain.Models.TravelAgentEmployee).Name + "_" + Guid.NewGuid().ToString();
                if (item is BasicEntityWithAuditInfo)
                {
                    (item as BasicEntityWithAuditInfo).CreatedBy = _httpContextAccessor.HttpContext?.User.FindFirst("userCode")?.Value;
                    (item as BasicEntityWithAuditInfo).CreatedDate = DateTime.Now;
                }
            }


            foreach (var item in createdEntity.TravelAgentPOSs)
            {
                item.Code = typeof(Domain.Models.TravelAgentPOS).Name + "_" + Guid.NewGuid().ToString();
                if (item is BasicEntityWithAuditInfo)
                {
                    (item as BasicEntityWithAuditInfo).CreatedBy = _httpContextAccessor.HttpContext?.User.FindFirst("userCode")?.Value;
                    (item as BasicEntityWithAuditInfo).CreatedDate = DateTime.Now;
                }
            }
            return createdEntity;
        }

        protected async Task<ActionResult<TravelAgentOfficeGetDto>> GetTravelAgentOfficeByUserCode()
        {
            var userCode = _httpContextAccessor.HttpContext?.User.FindFirst("userCode")?.Value;
            var result = await QueryExcuter(null).FirstOrDefaultAsync(x => x.UserCode.Equals(userCode)) ??
                throw new EntityNotFoundException(typeof(Domain.Models.TravelAgentOffice).Name, userCode.ToString() ?? "");
            return await Task.FromResult(_mapper.Map<TravelAgentOfficeGetDto>(result));
        }
    }
}
