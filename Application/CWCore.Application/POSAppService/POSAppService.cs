﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CWCore.Application.POSAppService.Dtos;
using CWCore.Application.POSAppService.Validations;
using CWCore.Data.DbContext;
using Infrastructure.Application;
using Infrastructure.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace CWCore.Application.POSAppService
{
    
    public class POSAppService : BaseAppService<CWDbContext, Domain.Models.POS, POSGetDto, POSGetDto, POSCreateDto, POSUpdateDto, SieveModel>, IPOSAppService
    {
        IHttpContextAccessor _httpContextAccessor;
        CWDbContext _serviceDbContext;
        IMapper _mapper;
        public POSAppService(CWDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, POSValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
            _mapper = mapper;
        }
        public async Task<ICollection<POSGetDto>> GetByPOSKey(string key)
        {

            var result = _serviceDbContext.POSs.Where(predicate => predicate.Key.ToLower() == key.ToLower()).ToList();
            return await Task.FromResult(_mapper.Map<ICollection<POSGetDto>>(result));
        }

        protected override IQueryable<Domain.Models.POS> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }

    }

    
}