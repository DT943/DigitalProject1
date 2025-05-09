﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Controllers
{
    public interface IBaseController<TAppService, TEntity, TGetAllDto, TGetDto, TCreatDto, TUpdateDto, TFilterDto>
    {
        Task<ActionResult<TGetDto>> Create(TCreatDto dto);
        Task<ActionResult<TGetDto>> Delete(int id);
        Task<ActionResult<TGetDto>> Get(int id);
        Task<ActionResult<TGetAllDto>> GetAll([FromQuery] TFilterDto sieve);
        Task<ActionResult<TGetDto>> Update(TUpdateDto dto);
        Task<ActionResult<TGetDto>> FakeDelete(int id,bool delete);
    }
}
