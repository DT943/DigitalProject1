﻿using Infrastructure.Domain.Models;
using Sieve.Models;
using Sieve.Services;
using Infrastructure.Data.BaseDbContext;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Application.Exceptions;
using AutoMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using Infrastructure.Application.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Infrastructure.Application.BasicDto;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.Application
{
    public abstract class BaseAppService<TServiceDbContext, TEntity, TGetAllDto, TGetDto, TCreateDto, TUpdateDto, TFilterDto> : IBaseAppService<TGetAllDto, TGetDto, TCreateDto, TUpdateDto, TFilterDto>
        where TServiceDbContext : BaseDbContext<TServiceDbContext>
        where TEntity : BasicEntity
        where TCreateDto : IValidatableDto
        where TUpdateDto : IEntityUpdateDto
        where TFilterDto : SieveModel
    {
        protected readonly TServiceDbContext _serviceDbContext;
        protected readonly ISieveProcessor _processor;
        protected readonly IMapper _mapper;
        protected AbstractValidator<IValidatableDto> _validations;
        protected readonly IHttpContextAccessor _httpContextAccessor;

        public BaseAppService(TServiceDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, AbstractValidator<IValidatableDto> validations, IHttpContextAccessor httpContextAccessor)
        {
            _serviceDbContext = serviceDbContext;
            _processor = processor;
            _mapper = mapper;
            _validations = validations;
            _httpContextAccessor = httpContextAccessor;
        }
        protected virtual IQueryable<TEntity> QueryExcuter(TFilterDto input) => _serviceDbContext.Set<TEntity>().OrderByDescending(item => item.Id).AsQueryable();
        public virtual async Task<TGetDto> Delete(int id)
        {
            var result = await _serviceDbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id.Equals(id)) ?? throw new EntityNotFoundException(typeof(TEntity).Name, id.ToString() ?? "");
            _serviceDbContext.Set<TEntity>().Remove(result);
            await _serviceDbContext.SaveChangesAsync();
            return await Task.FromResult(_mapper.Map<TGetDto>(result));
        }
        public virtual async Task<TGetDto> Get(int id)
        {
            var result = await QueryExcuter(null).FirstOrDefaultAsync(x => x.Id.Equals(id)) ??
            throw new EntityNotFoundException(typeof(TEntity).Name, id.ToString() ?? "");

            return await Task.FromResult(_mapper.Map<TGetDto>(result));
        }

        public virtual async Task<TGetDto> GetByCode(string code)
        {

            var result = await QueryExcuter(null).FirstOrDefaultAsync(x => x.Code.Equals(code)) ??
            throw new EntityNotFoundException(typeof(TEntity).Name, code.ToString() ?? "");
            return await Task.FromResult(_mapper.Map<TGetDto>(result));
        }

        protected virtual TEntity BeforCreate(TCreateDto create)
        {
            TEntity createdEntity = _mapper.Map<TEntity>(create);
            createdEntity.Code = typeof(TEntity).Name + "_" + Guid.NewGuid().ToString();
            if (createdEntity is BasicEntityWithAuditInfo)
            {
                (createdEntity as BasicEntityWithAuditInfo).CreatedBy = _httpContextAccessor.HttpContext?.User.FindFirst("userCode")?.Value;
                (createdEntity as BasicEntityWithAuditInfo).CreatedDate = DateTime.Now;
            }
            return createdEntity;
        }


        protected virtual TEntity BeforUpdate(TUpdateDto update, TEntity entity)
        {

            if (entity is BasicEntityWithAuditInfo)
            {
                (entity as BasicEntityWithAuditInfo).ModifiedBy = _httpContextAccessor.HttpContext?.User.FindFirst("userCode")?.Value;
                (entity as BasicEntityWithAuditInfo).ModifiedDate = DateTime.Now;
            }
            return _mapper.Map(update, entity);
        }

        // protected virtual TEntity BeforUpdate2(TUpdateDto update, TEntity entity) => _mapper.Map(update, entity);


        public virtual async Task<TGetDto> Create(TCreateDto create)
        {
            var validationResult = await _validations.ValidateAsync(create, options => options.IncludeRuleSets("create", "default"));
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var entity = BeforCreate(create);
            var result = await _serviceDbContext.Set<TEntity>().AddAsync(entity);
            try
            {
                await _serviceDbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
            }
            return await Get(result.Entity.Id);
        }
        public virtual async Task<TEntity> FindById(int id)
        {
            return await QueryExcuter(null).FirstOrDefaultAsync(x => x.Id.Equals(id)) ?? throw new EntityNotFoundException(typeof(TEntity).Name, id.ToString() ?? "");

        }
        public virtual async Task<TGetDto> Update(TUpdateDto update)
        {
            var validationResult = await _validations.ValidateAsync(update, options => options.IncludeRuleSets("update", "default"));
            if (!validationResult.IsValid)
                throw new FluentValidation.ValidationException(validationResult.Errors);

            var oldEntity = await FindById(update.Id);
            var newEntity = BeforUpdate(update, oldEntity);
            var result = _serviceDbContext.Set<TEntity>().Update(newEntity);
            try
            {
                await _serviceDbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
            }

            return await Get(result.Entity.Id);
        }

        public virtual async Task<PaginatedResult<TGetAllDto>> GetAll(TFilterDto input)
        {
            try
            {
                var result2 = await QueryExcuter(input).AsNoTracking().ToListAsync();

            }
            catch (Exception e)
            {

            }
            var result = await QueryExcuter(input).AsNoTracking().ToListAsync();
            var filterdResultForCount = _processor.Apply(input, result.AsQueryable(), applyPagination: false);
            var filterdResult = _processor.Apply(input, filterdResultForCount);
            var count = filterdResultForCount.Count();

            return new PaginatedResult<TGetAllDto>
            {
                Items = await Task.FromResult(_mapper.Map<List<TGetAllDto>>(filterdResult)),
                TotalCount = count,
                Page = input.Page ?? 1,
                PageSize = input.PageSize ?? count
            };
        }

         
        public virtual async Task<TGetDto> FakeDelete(bool delete, int id)
        {
        

            var oldEntity = await FindById(id);
            var newEntity = _mapper.Map<TEntity>(oldEntity);
            if (newEntity is BasicEntityWithAuditAndFakeDelete)
            {
                (newEntity as BasicEntityWithAuditAndFakeDelete).IsDeleted = delete;
                (newEntity as BasicEntityWithAuditInfo).ModifiedBy = _httpContextAccessor.HttpContext?.User.FindFirst("userCode")?.Value;
                (newEntity as BasicEntityWithAuditInfo).ModifiedDate = DateTime.Now;
            }
            else
                throw new EntityNotFoundException(typeof(TEntity).Name, "this Entity Doesn't Include Fake Delete");
            var result = _serviceDbContext.Set<TEntity>().Update(newEntity);
            try
            {
                await _serviceDbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
            }

            return await Get(result.Entity.Id);
        }
    }
    
}
