using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Domain.Models;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace BookingEngine.Application.Filters
{
    public class BookingEngineFiltersConfiguration: ISieveConfiguration
    {

        public void Configure(SievePropertyMapper mapper)
        {

            // Filter on parent AirPort using a computed shadow property
            mapper.Property<AirPort>(p => p.IATACode)
                .CanFilter().CanSort().HasName("iata");
            mapper.Property<OTAUser>(p => p.POS)
                .CanFilter().CanSort().HasName("pos");

            mapper.Property<StripeResult>(p => p.Pnr)
                .CanFilter().CanSort().HasName("pnr"); 

            mapper.Property<StripeResult>(p => p.SessionId)
                .CanFilter().CanSort().HasName("sessionid");



            mapper.Property<ExchangeRate>(p => p.FromCurrency)
                .CanFilter().CanSort().HasName("fromcurrency");
            mapper.Property<ExchangeRate>(p => p.ToCurrency)
                .CanFilter().CanSort().HasName("tocurrency");

        }

    }
}

