using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using BookingEngine.Domain.Models;
using FluentValidation;
using Stripe;

namespace BookingEngine.Application.WrappingAppService.WrappingAirSeatMapAppService
{
    public class WrappingAirSeatMapAppService
    {
        private readonly string _endpoint;
        private readonly string _username;
        private readonly string _password;
        private readonly HttpClient _httpClient;

        public WrappingAirSeatMapAppService(HttpClient httpClient, string endpoint, string username, string password)
        {
            _httpClient = httpClient;
            _endpoint = endpoint;
            _username = username;
            _password = password;
        }
        /*
        public string CreateSeatMapRequest(List<SegmentModel> segments, string transactionId, string flightType)
        {
            var segmentBuilder = new StringBuilder();

            foreach (var segment in segments)
            {
                string departureDateTime = $"{segment.departure_date}T{segment.departure_time}";
                string arrivalDateTime = $"{segment.arrival_date}T{segment.arrival_time}";

                segmentBuilder.Append($@"
                    <ns:SeatMapRequest TravelerRefNumberRPHs="">
                        <ns:FlightSegmentInfo ArrivalDateTime="{ arrivalDateTime}" DepartureDateTime="{ departureDateTime}" 
                            FlightNumber = "{segment.FlightNumber}" RPH = "{segment.rph}" ResCabinClass = "{flightType}" >
                            < ns:DepartureAirport LocationCode = "{segment.origin_code}" Terminal = "TerminalX" />
                            < ns:ArrivalAirport LocationCode = "{segment.destination_code}" Terminal = "TerminalX" />
                            < ns:OperatingAirline Code = "XH" />
                        </ ns:FlightSegmentInfo >
                    </ ns:SeatMapRequest > ");
            
                    
                                     
            }

            return $@"
                <soapenv:Envelope xmlns:ns=\"http://www.opentravel.org/OTA/2003/05\"
        xmlns: soapenv =\"http://schemas.xmlsoap.org/soap/envelope/\">
        < soapenv:Header >

            < wsse:Security soapenv:mustUnderstand =\"1\"
                            xmlns: wsse =\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\">
            < wsse:UsernameToken >
                                < wsse:Username >{ _username}</ wsse:Username >
                                < wsse:Password Type =\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText\">{_password}</wsse:Password>
                            </ wsse:UsernameToken >
                        </ wsse:Security >
                    </ soapenv:Header >
                    < soapenv:Body >
                        < ns:OTA_AirSeatMapRQ EchoToken =\"11810113621255-577396696\" PrimaryLangID=\"en-us\" SequenceNmbr=\"1\" TransactionIdentifier=\"{transactionId}\" Version=\"20061.00\">
                            < ns:POS >
                                < ns:Source TerminalID =\"TestUser/Test Runner\">
                                    < ns:RequestorID ID =\"{_username}\" Type=\"4\" />
                                    < ns:BookingChannel Type =\"12\" />
                                </ ns:Source >
                            </ ns:POS >
                            < ns:SeatMapRequests >
                            { segmentBuilder}
                            </ ns:SeatMapRequests >
                        </ ns:OTA_AirSeatMapRQ >
                    </ soapenv:Body >
                </ soapenv:Envelope > ";
        }
        */
        public async Task<string> CallSeatMapApiAsync(string xmlRequest, string jsessionId = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _endpoint);
            request.Headers.Add("SOAPAction", "http://www.opentravel.org/OTA/2003/05/OTA_AirSeatMap");
            request.Content = new StringContent(xmlRequest, Encoding.UTF8, "text/xml");

            if (!string.IsNullOrEmpty(jsessionId))
            {
                request.Headers.Add("Cookie", $"JSESSIONID={jsessionId}");
            }

            try
            {
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return $"{{ \"status\": \"error\", \"message\": \"{ex.Message}\" }}";
            }
        }

        public object ParseResponse(string xmlContent)
        {
            if (string.IsNullOrWhiteSpace(xmlContent)) return new List<object>();

            XNamespace ns1 = "http://www.opentravel.org/OTA/2003/05";
            var root = XElement.Parse(xmlContent);
            var errorElements = root.Descendants(ns1 + "Error");

            if (errorElements != null && errorElements.Any())
            {
                var errorList = new List<object>();
                foreach (var error in errorElements)
                {
                    errorList.Add(new
                    {
                        code = error.Attribute("Code")?.Value ?? "UNKNOWN",
                        message = error.Attribute("ShortText")?.Value ?? "Unknown error",
                        type = error.Attribute("Type")?.Value ?? "ERR"
                    });
                }

                return new
                {
                    status = "error",
                    errors = errorList
                };
            }

            var seatMap = new List<object>();
            var cabinClasses = root.Descendants(ns1 + "CabinClass");
            string transactionId = root.Descendants(ns1 + "OTA_AirSeatMapRS").Attributes("TransactionIdentifier").FirstOrDefault()?.Value ?? "";

            foreach (var cabin in cabinClasses)
            {
                var cabinType = cabin.Attribute("CabinType")?.Value;
                foreach (var row in cabin.Descendants(ns1 + "AirRow"))
                {
                    var rowNumber = row.Attribute("RowNumber")?.Value;
                    foreach (var seat in row.Descendants(ns1 + "AirSeat"))
                    {
                        seatMap.Add(new
                        {
                            cabin = cabinType,
                            row = rowNumber,
                            seat = seat.Attribute("SeatNumber")?.Value,
                            availability = seat.Attribute("SeatAvailability")?.Value,
                            characteristics = seat.Attribute("SeatCharacteristics")?.Value
                        });
                    }
                }
            }

            if (!seatMap.Any())
            {
                return new
                {
                    status = "error",
                    errors = new[]
                    {
                        new
                        {
                            code = "",
                            message = "No seat map found in response.",
                            type = ""
                        }
                    }
                };
            }

            return new
            {
                transaction_id = transactionId,
                seat_map = seatMap
            };
        }
    }

    public class SegmentModel
    {
        public string FlightNumber { get; set; }
        public string rph { get; set; }
        public string origin_code { get; set; }
        public string destination_code { get; set; }
        public string departure_date { get; set; }
        public string departure_time { get; set; }
        public string arrival_date { get; set; }
        public string arrival_time { get; set; }
    }
}
