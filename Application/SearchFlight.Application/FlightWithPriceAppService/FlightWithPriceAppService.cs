using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SearchFlight.Application.FlightPricing
{
    /*
    public class FlightPriceManagerService
    {
        private readonly AirAvailabilityService _airAvailService;
        private readonly AirPriceService _airPriceService;
        private readonly BaggageAncillariesManager _baggageAncillariesManager;
        private readonly SeatMapAncillariesManager _seatMapAncillariesManager;
        private readonly SSRAncillariesManager _ssrAncillariesManager;
        private readonly DecryptedOTAPasswordManager _decryptedOTAPasswordManager;
        private readonly GetAirportInfoService _airportInfoService;
        private readonly string _username;
        private readonly string _password;
        private readonly decimal _exchangeRate;

        public FlightPriceManagerService(string pos, IConfiguration config)
        {
            string endpoint = config["OTA:Endpoint"] ?? "https://reservations.flycham.com/webservices/services/AAResWebServices";

            _decryptedOTAPasswordManager = new DecryptedOTAPasswordManager();
            (_username, _password) = _decryptedOTAPasswordManager.GetUsernameAndPassword(pos);
            if (string.IsNullOrWhiteSpace(_username) || string.IsNullOrWhiteSpace(_password))
                throw new Exception("Invalid OTA credentials");

            _exchangeRate = decimal.Parse(config[$"Exchange:{pos}"], CultureInfo.InvariantCulture);

            _airAvailService = new AirAvailabilityService(endpoint, _username, _password);
            _airPriceService = new AirPriceService(endpoint, _username, _password);
            _baggageAncillariesManager = new BaggageAncillariesManager(pos);
            _seatMapAncillariesManager = new SeatMapAncillariesManager(pos);
            _ssrAncillariesManager = new SSRAncillariesManager(pos);
            _airportInfoService = new GetAirportInfoService();
        }

        public async Task<(bool isAncillary, bool isSSR, bool isBaggage, bool isSeatMap)> GetAncillaryStatusAsync(Dictionary<string, object> baggageReq, Dictionary<string, object> seatMapReq, Dictionary<string, object> ssrReq)
        {
            var ssrResult = await _ssrAncillariesManager.GetSSRAsync(ssrReq);
            var baggageResult = await _baggageAncillariesManager.GetBaggageAsync(baggageReq);
            var seatMapResult = await _seatMapAncillariesManager.GetSeatMapAsync(seatMapReq);

            bool isSSR = ssrResult?["status"]?.ToString() != "error";
            bool isBaggage = baggageResult?["status"]?.ToString() != "error";
            bool isSeatMap = seatMapResult?["status"]?.ToString() != "error";

            return (isSSR && isBaggage && isSeatMap, isSSR, isBaggage, isSeatMap);
        }

        public async Task<List<Dictionary<string, object>>> GetFlightAvailabilityAndPricingAsync(Dictionary<string, object> flightRequest)
        {
            // Validate flight request
            string flightType = flightRequest["flighttype"].ToString();
            string departureDate = flightRequest["date"].ToString();
            string returnDate = flightRequest.ContainsKey("date_return") ? flightRequest["date_return"].ToString() : null;
            if (flightType == "Return" && DateTime.Parse(departureDate) > DateTime.Parse(returnDate))
                return new List<Dictionary<string, object>> { new() { ["error"] = "Return date should be after departure date" } };

            // Call availability
            var availabilityRequest = _airAvailService.CreateRequest(flightRequest);
            var availabilityXml = await _airAvailService.CallApiAsync(availabilityRequest);
            var availabilityResults = _airAvailService.ParseAvailabilityResponse(availabilityXml, flightType);

            if (availabilityResults is Dictionary<string, object> error && error.ContainsKey("errors"))
                return new List<Dictionary<string, object>> { new() { ["error"] = error["errors"] } };

            var results = new List<Dictionary<string, object>>();

            foreach (var result in availabilityResults.Cast<Dictionary<string, object>>())
            {
                var flightInfo = (Dictionary<string, object>)result["flight_info"];
                var segments = (List<Dictionary<string, object>>)flightInfo["segments"];

                string transactionId = await _airAvailService.GetTransactionIdAsync(availabilityRequest);
                var priceRequest = _airPriceService.CreateRequest(transactionId, segments, flightRequest);
                var priceXml = await _airPriceService.CallApiAsync(priceRequest);
                var priceResult = _airPriceService.ParsePriceResponse(priceXml);

                if (priceResult is Dictionary<string, object> priceError && priceError.ContainsKey("errors"))
                    continue;

                var pricingInfo = _airPriceService.ExtractFareBreakdown(priceResult, _exchangeRate);
                var totalFare = pricingInfo.Sum(p => decimal.Parse(p["TotalFare"].ToString()));

                // Airport info can be fetched with _airportInfoService.CallByIataCodeAsync(...)
                // Segment conversion and ancillary check here if needed...

                results.Add(new Dictionary<string, object>
                {
                    ["transaction_id"] = transactionId,
                    ["total_fare"] = totalFare.ToString("F2"),
                    ["pricing_info"] = pricingInfo,
                    ["segments"] = segments,
                    ["flight_type"] = flightType,
                    ["cheapestOne"] = 0,
                });
            }

            // Set cheapest flag
            if (results.Count > 0)
            {
                var minFare = results.Min(r => decimal.Parse(r["total_fare"].ToString()));
                foreach (var res in results)
                    if (decimal.Parse(res["total_fare"].ToString()) == minFare)
                        res["cheapestOne"] = 1;
            }

            return results;
        }
    }
    */
}
