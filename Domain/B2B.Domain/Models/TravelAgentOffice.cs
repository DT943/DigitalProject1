using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace B2B.Domain.Models
{
    public class TravelAgentOffice : BasicEntityWithAuditInfo
    {
        [Required]
        [MaxLength(100)]
        public  string TravelAgentNameISA{  get; set; }


        [MaxLength(100)]
        public string AgencyName { get; set; }
        [Required]
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

        [MaxLength(50)]
        public string SYD { get; set; }

        [MaxLength(50)]
        public string SYP { get; set; }
        public ICollection<TravelAgentEmployee> TravelAgentEmployees { get; set; }


    }
}
