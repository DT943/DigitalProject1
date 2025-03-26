
using Gallery.Application.FileAppservice.Dtos;
using Gallery.Application.FileAppservice.Validations;
using Gallery.Data.DbContext;
using Infrastructure.Application;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Application.Exceptions;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.StaticFiles;
using FluentValidation;
using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;

namespace Gallery.Application.FileAppservice
{
    public class FileAppService : BaseAppService<GalleryDbContext, Domain.Models.File, FileGetDto, FileGetDto, FileCreateDto, FileUpdateDto, SieveModel>, IFileAppService
    {
        IHttpContextAccessor _httpContextAccessor;
        GalleryDbContext _serviceDbContext;
        FileValidator _fileValidator;
        public FileAppService(GalleryDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, FileValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
            _fileValidator = validations;
        }

        public override async Task<FileGetDto> Create(FileCreateDto createDto)
        {

            if (!string.IsNullOrEmpty(createDto.GalleryCode))
            {
                var galleryByCode = await _serviceDbContext.Galleries.Where(s => s.Code.Equals(createDto.GalleryCode)).FirstOrDefaultAsync();
                createDto.GalleryId = galleryByCode.Id;
            }

            var validationResult = await _fileValidator.ValidateAsync(createDto, options => options.IncludeRuleSets("create", "default"));
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            createDto.Path = null;
            const long maxFileSize = 1024 * 1024 * 1024; // 5MB in bytes

            if (createDto.File != null && createDto.File.Length > 0)
            {
                if (createDto.File.Length > maxFileSize)
                {
                    throw new ValidationException(new List<ValidationFailure> { new ValidationFailure("File", $"File size exceeds the maximum allowed limit of {maxFileSize / (1024 * 1024 * 1024)}GB.") });

                }

                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "images");

                // Create the folder if it doesn't exist
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var filePath = Path.Combine(folderPath, createDto.File.FileName);

                // Save the file to the folder
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await createDto.File.CopyToAsync(fileStream);
                }
                createDto.Path = filePath;
                //return Ok(new { filePath });
            }
            else
                 throw new ValidationException(new List<ValidationFailure>{ new ValidationFailure("File", "No file uploaded.")});


            if (createDto == null || string.IsNullOrWhiteSpace(createDto.Path))
            {
                throw new ValidationException(new List<ValidationFailure> { new ValidationFailure("File", "Invalid file path.") });

            }

            if (!System.IO.File.Exists(createDto.Path))
            {
                throw new ValidationException(new List<ValidationFailure> { new ValidationFailure("File", "File Path Not Found") });
            }

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(createDto.Path, out var contentType))
            {
                contentType = "application/octet-stream"; // Default MIME type
            }

            // Extract file type safely
            var fileType = contentType.Contains("/") ? contentType.Split("/")[0] : "unknown";

            var fileName = Path.GetFileName(createDto.Path);
            var Request = _httpContextAccessor.HttpContext?.Request;
            // Base URL where static files are served
            var baseUrl = $"{Request.Scheme}://{Request.Host}/images";
            var fileUrl = $"{baseUrl}/{fileName}";
            // Update DTO directly
            createDto.FileType = fileType;
            createDto.MimeType = contentType;
            long fileSizeBytes = new FileInfo(createDto.Path).Length;
            createDto.Size = (float)(fileSizeBytes / (1024.0 * 10240.0));
            createDto.FileUrlPath = fileUrl;
            createDto.FileName = fileName;

            if (contentType.StartsWith("image"))
            {
                try
                {
                    using (var image = Image.FromFile(createDto.Path))
                    {
                        createDto.ImageWidth = image.Width;
                        createDto.ImageHeight = image.Height;
                    }
                }
                catch (Exception ex)
                {
                }

            }
            return await base.Create(createDto);
        }

        public async Task<List<FileGetDto>> CreateMultipleFiles(MultiFileCreateDto multiFileCreateDto)
        {
        
             
            var validationResult = await _fileValidator.ValidateAsync(multiFileCreateDto, options => options.IncludeRuleSets("multiCreate", "default"));
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            if (multiFileCreateDto == null || multiFileCreateDto.Files == null || !multiFileCreateDto.Files.Any())
            {
                throw new ValidationException(new List<ValidationFailure> { new ValidationFailure("File", "No file data provided.") });

            }

            if (string.IsNullOrEmpty(multiFileCreateDto.GalleryCode))
            {
                throw new ValidationException(new List<ValidationFailure> { new ValidationFailure("File", "Gallery code is required.") });
            }
            var gallery = await _serviceDbContext.Galleries.FirstOrDefaultAsync(g => g.Code.Equals(multiFileCreateDto.GalleryCode));

            if (gallery == null)
            {
                throw new ValidationException(new List<ValidationFailure> { new ValidationFailure("File", $"Gallery with code {multiFileCreateDto.GalleryCode} not found.") });
            }

            var results = new List<FileGetDto>();

            foreach (var fileDto in multiFileCreateDto.Files)
            {
                fileDto.GalleryCode = null;
                fileDto.GalleryId = gallery.Id; 
                var result = await Create(fileDto);
                results.Add(result);
                

            }

            return results;
        }

        public override async Task<FileGetDto> Update(FileUpdateDto updateDto)
        {
            var validationResult = await _fileValidator.ValidateAsync(updateDto, options => options.IncludeRuleSets("update", "default"));
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            FileGetDto fileGetDto = await base.Get(updateDto.Id);
            updateDto.Path = fileGetDto.Path;


            if (updateDto == null || string.IsNullOrWhiteSpace(updateDto.Path))
            {
                throw new ValidationException(new List<ValidationFailure> { new ValidationFailure("File", "Invalid file path.") });
            }

            if (!System.IO.File.Exists(updateDto.Path))
            {
                throw new ValidationException(new List<ValidationFailure> { new ValidationFailure("File", "File Path Not Found") });
            }

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(updateDto.Path, out var contentType))
            {
                contentType = "application/octet-stream"; // Default MIME type
            }

            // Extract file type safely
            var fileType = contentType.Contains("/") ? contentType.Split("/")[0] : "unknown";

            var fileName = Path.GetFileName(updateDto.Path);

            var Request = _httpContextAccessor.HttpContext?.Request;

            // Base URL where static files are served
            var baseUrl = $"{Request.Scheme}://{Request.Host}/images";
            var fileUrl = $"{baseUrl}/{fileName}";
            // Update DTO directly
            updateDto.FileType = fileType;
            updateDto.MimeType = contentType;
            long fileSizeBytes = new FileInfo(updateDto.Path).Length;
            updateDto.Size = (float)(fileSizeBytes / (1024.0 * 10240.0));
            updateDto.FileUrlPath = fileUrl;
            updateDto.FileName = fileName;

            if (contentType.StartsWith("image"))
            {
                try
                {
                    using (var image = Image.FromFile(updateDto.Path))
                    {
                        updateDto.ImageWidth = image.Width;
                        updateDto.ImageHeight = image.Height;
                    }
                }
                catch (Exception ex)
                {
                }

            }
            return await base.Update(updateDto);
        }

        public override async Task<FileGetDto> Delete(int id)
        {
            FileGetDto fileGetDto = await base.Get(id);

            var filePath = fileGetDto.Path;

            if (!System.IO.File.Exists(filePath))
            {
                throw new ValidationException(new List<ValidationFailure> { new ValidationFailure("File", "Invalid file path.") });
            }

            var deletedEntity = await base.Delete(id);

            bool checkFile = await CheckPath(filePath);
            if (!checkFile)
            try
            {
                System.IO.File.Delete(filePath);
            }
            catch (Exception ex)
            {
                    throw new ValidationException(new List<ValidationFailure> { new ValidationFailure("File", $"Error deleting file: {ex.Message}") });
            }
           return deletedEntity;
        }
        public async Task<bool>CheckPath(string path)
        {
            return await _serviceDbContext.Files.AnyAsync(f => f.Path.Equals(path));
        }


        public async Task<IEnumerable<FileGetDto>> GetRelatedFileGallery(int GalleryId)
        {
            return _mapper.Map<List<FileGetDto>>( _serviceDbContext.Files.Where(f => f.GalleryId == GalleryId).ToList());
        }

        public async Task<IEnumerable<FileGetDto>> GetRelatedFileGalleryByCodeAsync(string GalleryCode)
        {
            var gallery = _serviceDbContext.Galleries.Where(f => f.Code == GalleryCode).FirstOrDefault();
            if (gallery == null) _mapper.Map<List<FileGetDto>>(new List<FileGetDto>());

            return _mapper.Map<List<FileGetDto>>(_serviceDbContext.Files.Where(f => f.GalleryId == gallery.Id).ToList());
        }

        protected override IQueryable<Domain.Models.File> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }

 
    }
}
