using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Application.TravelAgentOffice.Dto
{
    public class TravelAgentOfficeGetDto
    {
        public int Id { get; set; }
        public string TravelAgentNameISA { get; set; }
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
        public string SYD { get; set; }
        public string SYP { get; set; }
    }

    public class TravelAgentOfficeGetAllDto
    {
        public int Id { get; set; }
        public string TravelAgentNameISA { get; set; }
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
        public string SYD { get; set; }
        public string SYP { get; set; }
    }
}
