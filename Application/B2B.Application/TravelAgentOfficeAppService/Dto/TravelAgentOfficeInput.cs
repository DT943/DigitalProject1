using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.TravelAgentEmployeeAppService.Dto;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;
using Infrastructure.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace B2B.Application.TravelAgentOffice.Dto
{
    public class TravelAgentOfficeCreateDto : IValidatableDto
    {
        [MaxLength(100)]
        public string TravelAgentNameISA { get; set; }
        [MaxLength(100)]
        public string AgencyName { get; set; }

        [MaxLength(100)]
        public string AccellAeroUserName { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string FirstEmail { get; set; }

        [MaxLength(100)]
        public string? SecoundEmail { get; set; }

        [MaxLength(100)]
        public string POS { get; set; }

        [MaxLength(100)]
        public string Governate { get; set; }

        [MaxLength(100)]
        public string? VideoFileCode { get; set; }

        public string? VideoFileUrl { get; set; }

        [MaxLength(100)]
        public string? ImageFileCode { get; set; }
// send by email 
        public string? ImageFileUrl { get; set; }

        [MaxLength(100)]
        public string? PdfFileCode { get; set; }

        public string? PdfFileUrl { get; set; }

        [MaxLength(100)]
        public string? UserCode { get; set; }

        [MaxLength(100)]
        public string? ManagerCode { get; set; }


        public ICollection<TravelAgentEmployeeCreateDto> TravelAgentEmployees { get; set; }

        public ICollection<TravelAgentPOSCreateDto> TravelAgentPOSs { get; set; }


    }

    public class TravelAgentOfficeUpdateDto : IEntityUpdateDto
    {
        [MaxLength(100)]
        public string TravelAgentNameISA { get; set; }


        [MaxLength(100)]
        public string AgencyName { get; set; }

        [MaxLength(100)]
        public string AccellAeroUserName { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string FirstEmail { get; set; }

        [MaxLength(100)]
        public string? SecoundEmail { get; set; }

        [MaxLength(100)]
        public string POS { get; set; }

        [MaxLength(100)]
        public string Governate { get; set; }

        [MaxLength(100)]
        public string? VideoFileCode { get; set; }

        public string? VideoFileUrl { get; set; }

        [MaxLength(100)]
        public string? ImageFileCode { get; set; }

        public string? ImageFileUrl { get; set; }

        [MaxLength(100)]
        public string? PdfFileCode { get; set; }

        public string? PdfFileUrl { get; set; }

        [MaxLength(100)]
        public string? UserCode { get; set; }

        [MaxLength(100)]
        public string? ManagerCode { get; set; }
        public ICollection<TravelAgentEmployeeUpdateDto> TravelAgentEmployees { get; set; }
        public ICollection<TravelAgentPOSUpdateDto> TravelAgentPOSs { get; set; }
    }

    public class TravelAgentPOSCreateDto : IValidatableDto
    {
        public string POS { get; set; }

        [MaxLength(50)]
        public string OfficeCode { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Currency { get; set; }
    }

    public class TravelAgentPOSUpdateDto : IEntityUpdateDto
    {
        public string POS { get; set; }

        [MaxLength(50)]
        public string OfficeCode { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

    }


    public class TravelAgentProcessApproveDto
    {
        public int ApplicationId {  get; set; }

        public string ISAName { get; set; }
        public ICollection<TravelAgentPOSCreateDto> travelAgentPOSCreateDto { get; set; }
    }
}
