using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.Application.Dtos;

namespace Authentication.Application
{
    public interface IDepartmentAppService
    {
        public Task<DepartmentGetDto> Create(CreateDepartmentDto dto);
        public Task<DepartmentGetDto> Delete(int id);
        public Task<DepartmentGetDto> GetByCode(string code);
        public Task<DepartmentGetDto> Get(int id);

        public Task<DepartmentGetDto> Update(CreateDepartmentDto update);
        public Task<List<DepartmentGetDto>> GetAll();
        public Task<DepartmentGetDto> FakeDelete(bool delete, int id);

    }
}
