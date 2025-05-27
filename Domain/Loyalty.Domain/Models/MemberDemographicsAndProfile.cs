using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Infrastructure.Domain.Models;

namespace Loyalty.Domain.Models
{
    public class MemberDemographicsAndProfile : BasicEntity
    {
        [MaxLength(100)]
        public string UserCode { get; set; }
        [MaxLength(500)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string Initials { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string NameOnCard { get; set; }

        [MaxLength(100)]
        public string Gender { get; set; }

        [MaxLength(100)]
        public string Language { get; set; }

        public DateTime BirthDate { get; set; }

        [MaxLength(100)]
        public string MaritalStatus { get; set; }

        [MaxLength(100)]
        public string BussName { get; set; }

        [MaxLength(50)]
        public string PassportNumber { get; set; }

        [MaxLength(50)]
        public DateTime PassportExpiryDate { get; set; }

        [MaxLength(50)]
        public string IDNumber { get; set; }

        [MaxLength(100)]
        public string Nationality { get; set; }

        public string Designation {  get; set; }

        public int NumberOfChildren { get; set; }
    }
}
