using Infrastructure.Application.BasicDto;
using Infrastructure.Data.BaseDbContext;
using Infrastructure.Domain.Models;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Application
{
    public interface IBaseAppService<TGetAllDto,TGetDto, TCreatDto, TUpdateDto,TFilterDto>
    where TFilterDto : SieveModel
    {
        public Task<TGetDto> Create(TCreatDto dto);
        public Task<TGetDto> Delete(int id);
        public Task<TGetDto> GetByCode(string code);
        public Task<TGetDto> Get(int id);
        public Task<ApprovedResult<TGetDto>> Approve(int id, bool canApprove);
        public Task<TGetDto> Update(TUpdateDto update);
        public Task<PaginatedResult<TGetAllDto>> GetAll(TFilterDto input);
        public Task<TGetDto> FakeDelete(bool delete, int id);

        public Task<PaginatedResult<TGetAllDto>> GetApprovalNeededRecords(TFilterDto input);

    }
}
