using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace Offer.Domain.Models
{
    public class HolidayOffer : BasicEntityWithAuditInfo
    {
        [ForeignKey("Offer")]
        public int OfferID { get; set; }

        public Offer Offer;
        public List<string> IPAddress { get; set; }

        public List<string> POS { get; set; }
        public string Status { get; set; }
        public List<Domain.Models.Rule> Rules { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsIndiv { get; set; }
        public bool IsFamily { get; set; }
        public bool IsHoneyMoon { get; set; }
        public bool IsMedical { get; set; }

        public LuxuryHoliday LuxuryHoliday { get; set; }
        public PremiumHoliday PremiumHoliday { get; set; }
        public bool IsLuxury { get; set; }
        public bool IsPremium { get; set; }



    }
}
