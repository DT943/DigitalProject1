using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.SegmentAppService.Dtos;
using CMS.Application.StaticComponentAppService.Dto;

namespace CMS.Application.PageAppService.Dtos
{
    public class PageGetDto
    {
        public int Id { get; set; } 
        public string PageUrlName { get; set; }
        public string Language { get; set; }
        public string POS { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        public string? AwaitingApprovalUserCode { get; set; }

        public string? ApprovedUserCode { get; set; }

        public string ApprovalStatus { get; set; }
        public ICollection<SegmentGetDto> Segments { get; set; }

        public ICollection<StaticComponentGetDto> StaticComponents { get; set; }


    }


    public class PageGetUrl
    {
        public int Id { get; set; }

        public string PageUrlName { get; set; }
    }
}
