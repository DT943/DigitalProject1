using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingEngine.Application.MailModoAppService.Dtos;
using BookingEngine.Application.MailModoAppService.Validation;
using BookingEngine.Data.DbContext;
using FluentValidation;
using Infrastructure.Application;
using Infrastructure.Application.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace BookingEngine.Application.MailModoResultAppService
{
    public class MailModoResultAppService : BaseAppService<BookingEngineDbContext, Domain.Models.MailModoResult, MailModoGetDto, MailModoGetDto, MailModoCreateDto, MailModoUpdateDto, SieveModel>, IMailModoResultAppService
    {
        public MailModoResultAppService(BookingEngineDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, MailModoValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }

        protected override IQueryable<Domain.Models.MailModoResult> QueryExcuter(SieveModel input)
        {

            return base.QueryExcuter(input);
        }


    }
}
