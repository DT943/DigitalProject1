using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SearchFlight.Application.WrappingAppService
{
    public class WrappingAirPriceAppService
    {
        private readonly HttpClient _httpClient;
        private readonly string _username;
        private readonly string _password;
        private readonly string _endpoint;

        public WrappingAirPriceAppService(HttpClient httpClient, string endpoint, string username, string password)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
            _username = username ?? throw new ArgumentNullException(nameof(username));
            _password = password ?? throw new ArgumentNullException(nameof(password));
        }

        public string CreateAirPriceRequestXml(string transactionId, List<Dictionary<string, object>> segments,
            int adult, int child, int infant, string cabin, string flightType)
        {
            var sbSegments = new StringBuilder();
            foreach (var segment in segments)
            {
                var attrs = (Dictionary<string, object>)segment["attributes"];
                var depAirport = (Dictionary<string, object>)segment["departure_airport"];
                var arrAirport = (Dictionary<string, object>)segment["arrival_airport"];

                string journeyDurationAttr = attrs.ContainsKey("JourneyDuration")
                    ? $@" JourneyDuration=""{attrs["JourneyDuration"]}"""
                    : "";

                var cabinAttribute = (cabin == "C") ? $@" ResCabinClass=""{cabin}""" : "";

                sbSegments.Append($@"
                    <OriginDestinationOption>
                        <FlightSegment
                            ArrivalDateTime=""{attrs["ArrivalDateTime"]}""
                            DepartureDateTime=""{attrs["DepartureDateTime"]}""
                            FlightNumber=""{attrs["FlightNumber"]}""
                            RPH=""{attrs["RPH"]}""
                            SmokingAllowed=""false""
                            returnFlag=""false""{journeyDurationAttr}{cabinAttribute}>
                            <DepartureAirport LocationCode=""{depAirport["LocationCode"]}"" Terminal=""{depAirport.GetValueOrDefault("Terminal", "")}"" />
                            <ArrivalAirport LocationCode=""{arrAirport["LocationCode"]}"" />
                        </FlightSegment>
                    </OriginDestinationOption>");
            }

            string xml = $@"<?xml version=""1.0"" encoding=""UTF-8""?>
            <s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/""
                        xmlns:a=""http://www.w3.org/2005/08/addressing"">
              <s:Header>
                <Security xmlns=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
                  <wsse:UsernameToken
                      xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd""
                      xmlns:wsu=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"">
                    <wsse:Username>{_username}</wsse:Username>
                    <wsse:Password>{_password}</wsse:Password>
                  </wsse:UsernameToken>
                </Security>
              </s:Header>
              <s:Body xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
                <OTA_AirPriceRQ TimeStamp=""{DateTime.UtcNow:yyyy-MM-ddTHH:mm:ss}"" EchoToken=""{Guid.NewGuid()}"" SequenceNmbr=""1"" Version=""20061.00"" TransactionIdentifier=""{transactionId}"" xmlns=""http://www.opentravel.org/OTA/2003/05"">
                  <POS>
                    <Source TerminalID=""THR588"">
                      <RequestorID Type=""4"" ID=""{_username}"" />
                      <BookingChannel Type=""12"" />
                    </Source>
                  </POS>
                  <AirItinerary DirectionInd=""{flightType}"">
                    <OriginDestinationOptions>
                      {sbSegments}
                    </OriginDestinationOptions>
                  </AirItinerary>
                  <TravelerInfoSummary>
                    <AirTravelerAvail>
                      <PassengerTypeQuantity Code=""ADT"" Quantity=""{adult}"" />
                      <PassengerTypeQuantity Code=""CHD"" Quantity=""{child}"" />
                      <PassengerTypeQuantity Code=""INF"" Quantity=""{infant}"" />
                    </AirTravelerAvail>
                  </TravelerInfoSummary>
                </OTA_AirPriceRQ>
              </s:Body>
            </s:Envelope>";
            return xml;
        }

        public async Task<string> CallAirPriceApiAsync(string xmlRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _endpoint)
            {
                Content = new StringContent(xmlRequest, Encoding.UTF8, "text/xml")
            };

            request.Headers.Add("SOAPAction", "http://www.opentravel.org/OTA/2003/05/OTA_AirAvail");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public Dictionary<string, object> ParseTransactionResponse(string xmlData)
        {
            var result = new Dictionary<string, object>();
            if (string.IsNullOrWhiteSpace(xmlData)) return result;

            var doc = XDocument.Parse(xmlData);
            XNamespace ns = "http://www.opentravel.org/OTA/2003/05";

            var errors = doc.Descendants(ns + "Error");
            if (errors.Any())
            {
                var errorList = new List<Dictionary<string, string>>();
                foreach (var error in errors)
                {
                    errorList.Add(new Dictionary<string, string>
                    {
                        { "code", error.Attribute("Code")?.Value ?? "UNKNOWN" },
                        { "message", error.Attribute("ShortText")?.Value ?? "Unknown error" },
                        { "type", error.Attribute("Type")?.Value ?? "ERR" }
                    });
                }

                return new Dictionary<string, object>
                {
                    { "status", "error" },
                    { "errors", errorList }
                };
            }

            var transId = doc.Descendants(ns + "OTA_AirPriceRS").FirstOrDefault()?.Attribute("TransactionIdentifier")?.Value ?? "";
            return new Dictionary<string, object>
            {
                { "status", "success" },
                { "transaction_id", transId }
            };
        }

        public List<Dictionary<string, object>> ParseResponse(string xmlData)
        {
            var result = new List<Dictionary<string, object>>();
            if (string.IsNullOrWhiteSpace(xmlData)) return result;

            XNamespace ns = "http://www.opentravel.org/OTA/2003/05";
            var doc = XDocument.Parse(xmlData);

            var pricedItineraries = doc.Descendants(ns + "PricedItinerary");

            foreach (var pricedItin in pricedItineraries)
            {
                var pricingInfo = new Dictionary<string, object>();

                var itinTotalFare = pricedItin.Element(ns + "ItinTotalFare");
                if (itinTotalFare != null)
                {
                    var fares = new Dictionary<string, Dictionary<string, string>>();
                    foreach (var fare in itinTotalFare.Elements())
                    {
                        fares[fare.Name.LocalName] = fare.Attributes().ToDictionary(a => a.Name.LocalName, a => a.Value);
                    }
                    pricingInfo["ItinTotalFare"] = fares;
                }

                var fareBreakdowns = new List<Dictionary<string, object>>();
                foreach (var ptc in pricedItin.Elements(ns + "PTC_FareBreakdown"))
                {
                    var breakdown = new Dictionary<string, object>
                    {
                        { "passenger_fare", new Dictionary<string, object>() },
                        { "taxes", new List<Dictionary<string, string>>() },
                        { "fees", new List<Dictionary<string, string>>() },
                        { "fare_info", new Dictionary<string, object>() }
                    };

                    var passengerFare = ptc.Element(ns + "PassengerFare");
                    if (passengerFare != null)
                    {
                        var totalFare = passengerFare.Element(ns + "TotalFare");
                        if (totalFare != null)
                        {
                            ((Dictionary<string, object>)breakdown["passenger_fare"])["TotalFare"] =
                                totalFare.Attributes().ToDictionary(a => a.Name.LocalName, a => a.Value);
                        }

                        var taxes = passengerFare.Descendants(ns + "Tax");
                        foreach (var tax in taxes)
                        {
                            ((List<Dictionary<string, string>>)breakdown["taxes"]).Add(
                                tax.Attributes().Where(a => a.Name.LocalName != "DecimalPlaces")
                                .ToDictionary(a => a.Name.LocalName, a => a.Value));
                        }

                        var fees = passengerFare.Descendants(ns + "Fee");
                        foreach (var fee in fees)
                        {
                            ((List<Dictionary<string, string>>)breakdown["fees"]).Add(
                                fee.Attributes().ToDictionary(a => a.Name.LocalName, a => a.Value));
                        }
                    }

                    var fareInfo = ptc.Element(ns + "FareInfo");
                    if (fareInfo != null)
                    {
                        var fareDict = (Dictionary<string, object>)breakdown["fare_info"];
                        fareDict["attributes"] = fareInfo.Attributes().ToDictionary(a => a.Name.LocalName, a => a.Value);
                        var rule = fareInfo.Element(ns + "FareRuleReference");
                        fareDict["FareRuleReference"] = rule?.Value;
                    }

                    fareBreakdowns.Add(breakdown);
                }

                pricingInfo["FareBreakdowns"] = fareBreakdowns;
                result.Add(new Dictionary<string, object> { { "pricing_info", pricingInfo } });
            }

            return result;
        }
    }
}
