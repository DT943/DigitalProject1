using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gallery.Application.FileAppservice.Dtos;
using Gallery.Application.GalleryAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace Gallery.Application.FileAppservice
{
    public interface IFileAppService : IBaseAppService<FileGetDto, FileCreateDto, FileUpdateDto, SieveModel>
    {
        public bool CheckPath(string path);

        public Task<IEnumerable<FileGetDto>> GetRelatedFileGallery(int GalleryId);
    }
}
