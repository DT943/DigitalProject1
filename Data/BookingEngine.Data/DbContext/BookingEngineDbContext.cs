using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Domain.Models;
using Infrastructure.Data.BaseDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookingEngine.Data.DbContext
{
    public class BookingEngineDbContext: BaseDbContext<BookingEngineDbContext>
    {
        private readonly IConfiguration _configuration;

        public BookingEngineDbContext(DbContextOptions<BookingEngineDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema(GetSchemaName());
        }

        public DbSet<Domain.Models.AirPort> AirPorts { get; set; }

        public DbSet<AirPortTranslation> AirPortTranslations { get; set; }


        public DbSet<POS> POSs { get; set; }

        public DbSet<POSTranslation> POSTranslations { get; set; }


        public DbSet<PassengerInfo> PassengerInfos { get; set; }
        public DbSet<Telephone> Telephones { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Domain.Models.Reservation> Reservations { get; set; }
        public DbSet<Domain.Models.Contact> Contacts { get; set; }


        public DbSet<Domain.Models.SearchRequest> SearchRequests { get; set; }
        public DbSet<Domain.Models.OTAUser> OTAUsers { get; set; }
        public DbSet<Domain.Models.StripeResult> StripeResults { get; set; }



        public DbSet<InquirePNR> InquirePNRs { get; set; }
        public DbSet<BookFlightSegment> BookFlightSegments { get; set; }
        public DbSet<BookFare> BookFares { get; set; }
        public DbSet<BookPassenger> BookPassengers { get; set; }
        public DbSet<BookETicket> BookETickets { get; set; }
        public DbSet<BookContactInfo> BookContactInfos { get; set; }

        public DbSet<InquirePNRResponse> InquirePNRResponses { get; set; }

        public DbSet<BookFee> BookFees { get; set; }
        public DbSet<BookPassengerCount> BookPassengerCounts { get; set; }
        public DbSet<BookTax> BookTaxs { get; set; }


        public DbSet<ExchangeRate> ExchangeRates { get; set; }
        
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<Location> Locations { get; set; }

        public DbSet<PaymentPNRContact> PaymentPNRContacts { get; set; }
        public DbSet<PaymentPNRETicketInfo> PaymentPNRETicketInfos { get; set; }
        public DbSet<PaymentPNRFee> PaymentPNRFees { get; set; }
        public DbSet<PaymentPNRTax> PaymentPNRTaxs { get; set; }
        public DbSet<PaymentPNRPassenger> PaymentPNRPassengers { get; set; }
        public DbSet<PaymentPNRFlightSegment> PaymentPNRFlightSegments { get; set; }
        public DbSet<PaymentPNRResult> PaymentPNRResults { get; set; }

        public DbSet<StripeSessionData> StripeSessions { get; set; }

        public DbSet<MailModoResult> MailModoResults { get; set; }



    }
}
