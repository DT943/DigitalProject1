using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace CMS.Application.PageAppService.Dtos
{
    public class PageCreateDto : IValidatableDto
    {
        public string PageUrlName { get; set; }
        public string Language { get; set; }
        public string POS { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
        public string? Status { get; set; }
        public string Description { get; set; }

    }

    public class PageUpdateDto : IEntityUpdateDto
    {
        public string PageUrlName { get; set; }
        public string Language { get; set; }
        public string POS { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

    }
}
