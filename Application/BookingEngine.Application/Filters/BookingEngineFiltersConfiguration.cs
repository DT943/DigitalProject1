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

        }

    }
}

