using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sieve.Services;

namespace Gallery.Application.GalleryAppService.Processors
{
    public class GalleryProcessorConfiguration : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<Domain.Models.Gallery>(p => p.Name).CanFilter().CanSort().HasName("title");
            mapper.Property<Domain.Models.Gallery>(p => p.Id).CanFilter().CanSort().HasName("id");
            mapper.Property<Domain.Models.Gallery>(p => p.CreatedBy).CanFilter().CanSort().HasName("createdby");
            mapper.Property<Domain.Models.Gallery>(p => p.CreatedDate).CanFilter().CanSort().HasName("createddate");
            mapper.Property<Domain.Models.Gallery>(p => p.ModifiedBy).CanFilter().CanSort().HasName("modifiedby");
            mapper.Property<Domain.Models.Gallery>(p => p.ModifiedDate).CanFilter().CanSort().HasName("modifieddate");

            mapper.Property<Domain.Models.File>(p => p.Title).CanFilter().CanSort().HasName("title");
            mapper.Property<Domain.Models.File>(p => p.FileType).CanFilter().CanSort().HasName("filetype");

            mapper.Property<Domain.Models.File>(p => p.Id).CanFilter().CanSort().HasName("id");
            mapper.Property<Domain.Models.File>(p => p.GalleryId).CanFilter().CanSort().HasName("galleryid");
            mapper.Property<Domain.Models.File>(p => p.CreatedBy).CanFilter().CanSort().HasName("createdby");
            mapper.Property<Domain.Models.File>(p => p.CreatedDate).CanFilter().CanSort().HasName("createddate");
            mapper.Property<Domain.Models.File>(p => p.ModifiedBy).CanFilter().CanSort().HasName("modifiedby");
            mapper.Property<Domain.Models.File>(p => p.ModifiedDate).CanFilter().CanSort().HasName("modifieddate");

        }
    }
}
