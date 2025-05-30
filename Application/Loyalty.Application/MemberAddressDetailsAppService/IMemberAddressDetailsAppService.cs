﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application;
using Loyalty.Application.MemberAddressDetailsAppService.Dtos;
using Sieve.Models;

namespace Loyalty.Application.MemberAddressDetailsAppService
{
    public interface IMemberAddressDetailsAppService : IBaseAppService<MemberAddressDetailsGetAllDto, MemberAddressDetailsGetDto, MemberAddressDetailsCreateDto, MemberAddressDetailsUpdateDto, SieveModel>
    {
    }
}
