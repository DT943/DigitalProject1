using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.PageAppService.Dtos;
using CMS.Application.SegmentAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace CMS.Application.SegmentAppService
{
    public interface ISegmentAppService : IBaseAppService<SegmentGetDto, SegmentGetDto, SegmentCreateDto, SegmentUpdateDto, SieveModel>
    {
    }
}
