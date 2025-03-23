using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gallery.Application.GalleryAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace Gallery.Application.GalleryAppService
{
    public interface IGalleryAppService : IBaseAppService<GalleryGetDto, GalleryGetDto, GalleryCreateDto, GalleryUpdateDto, SieveModel>
    {
        Task<GalleryGetDto> GetByName(string name);
    }
}
