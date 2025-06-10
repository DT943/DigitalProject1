using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.TravelAgentEmployeeAppService.Dto;
using Infrastructure.Application.Validations;

namespace B2B.Application.TravelAgentOffice.Dto
{
    public class TravelAgentOfficeGetDto
    {
        public int Id { get; set; }
        public string TravelAgentNameISA { get; set; }
        public string? AgencyName { get; set; }
        public string AccellAeroUserName { get; set; }
        public string FirstEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? SecoundEmail { get; set; }
        public string POS { get; set; }
        public string Governate { get; set; }
        public string VideoFileCode { get; set; }
        public string VideoFileUrl { get; set; }
        public string ImageFileCode { get; set; }
        public string ImageFileUrl { get; set; }
        public string PdfFileCode { get; set; }
        public string PdfFileUrl { get; set; }
        public string UserCode { get; set; }
        public string ManagerCode { get; set; }
        public string SYD { get; set; }
        public string SYP { get; set; }

        public ICollection<TravelAgentEmployeeGetDto> TravelAgentEmployees { get; set; }
        public ICollection<TravelAgentPOSGetDto> TravelAgentPOSs { get; set; }
    }

    public class TravelAgentOfficeGetAllDto
    {
        public int Id { get; set; }
        public string TravelAgentNameISA { get; set; }
        public string AccellAeroUserName { get; set; }
        public string? AgencyName { get; set; }
        public string FirstEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? SecoundEmail { get; set; }
        public string POS { get; set; }
        public string Governate { get; set; }
        public string VideoFileCode { get; set; }
        public string VideoFileUrl { get; set; }
        public string ImageFileCode { get; set; }
        public string ImageFileUrl { get; set; }
        public string PdfFileCode { get; set; }
        public string PdfFileUrl { get; set; }
        public string UserCode { get; set; }
        public string ManagerCode { get; set; }
        public ICollection<TravelAgentEmployeeGetDto> TravelAgentEmployees { get; set; }
        public ICollection<TravelAgentPOSGetDto> TravelAgentPOSs { get; set; }
    }

    public class TravelAgentPOSGetDto  
    {
        public int Id { get; set; }
        public string POS { get; set; }

        [MaxLength(50)]
        public string OfficeCode { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Currency { get; set; }

    }
}
