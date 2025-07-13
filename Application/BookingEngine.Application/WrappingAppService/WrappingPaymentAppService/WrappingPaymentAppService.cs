using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BookingEngine.Application.PaymantAppService.Dtos;
using BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService.Dtos;
using BookingEngine.Application.WrappingAppService.WrappingPaymentAppService.Dtos;

namespace BookingEngine.Application.WrappingAppService.WrappingPaymentAppService
{
    public class WrappingPaymentAppService : IWrappingPaymentAppService
    {
        private readonly string _endpoint = "https://reservations.flycham.com/webservices/services/AAResWebServices";

        public async Task<PaymentSystemGetDto> PaymentAsync(PaymentSystemCreateDto request)
        {
            try
            {
                var soapRequest = BuildSoapRequest(request);
                var responseXml = await CallPaymentApiAsync(soapRequest);
                var parsed = XDocument.Parse(responseXml);
                return ParsePaymentResponse(parsed);
            }
            catch (Exception ex)
            {
                return new PaymentSystemGetDto
                {
                    Status = "error",
                    Error = new List<string> { "Exception: " + ex.Message }
                };
            }
        }

        private string BuildSoapRequest(PaymentSystemCreateDto request)
        {
            return $@"
                <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/""
                    xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
                    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                    <soap:Header>
                        <wsse:Security soap:mustUnderstand=""1""
                            xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
                            <wsse:UsernameToken wsu:Id=""UsernameToken-11632138""
                                xmlns:wsu=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"">
                                <wsse:Username>{request.UserName}</wsse:Username>
                                <wsse:Password Type=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText"">{request.Password}</wsse:Password>
                            </wsse:UsernameToken>
                        </wsse:Security>
                    </soap:Header>
                    <soap:Body xmlns:ns1=""http://www.isaaviation.com/thinair/webservices/OTA/Extensions/2003/05""
                        xmlns:ns2=""http://www.opentravel.org/OTA/2003/05"">
                        <ns2:OTA_AirBookModifyRQ EchoToken = """" PrimaryLangID=""en-us"" SequenceNmbr=""1"" TimeStamp="""" Version=""20061.00"">
                            <ns2:POS>
                                <ns2:Source TerminalID=""TestUser/Test Runner"">
                                    <ns2:RequestorID ID=""{request.UserName}"" Type=""4"" />
                                    <ns2:BookingChannel Type=""12"" />
                                </ns2:Source>
                            </ns2:POS>
                            <ns2:AirBookModifyRQ ModificationType=""9"">
                                <ns2:Fulfillment>
                                    <ns2:PaymentDetails>
                                        <ns2:PaymentDetail>
                                            <ns2:DirectBill>
                                                <ns2:CompanyName Code=""{request.CompanyName}""/>
                                            </ns2:DirectBill>
                                            <ns2:PaymentAmount Amount=""{request.Balance}"" CurrencyCode=""USD"" DecimalPlaces=""2"" />
                                        </ns2:PaymentDetail>
                                    </ns2:PaymentDetails>
                                </ns2:Fulfillment>
                                <ns2:BookingReferenceID ID=""{request.PNR}"" Type=""14"" />
                            </ns2:AirBookModifyRQ>
                        </ns2:OTA_AirBookModifyRQ>
                        <ns1:AAAirBookModifyRQExt>
                            <ns1:AALoadDataOptions>
                                <ns1:LoadTravelerInfo>true</ns1:LoadTravelerInfo>
                                <ns1:LoadAirItinery>true</ns1:LoadAirItinery>
                                <ns1:LoadPriceInfoTotals>true</ns1:LoadPriceInfoTotals>
                                <ns1:LoadFullFilment>true</ns1:LoadFullFilment>
                            </ns1:AALoadDataOptions>
                        </ns1:AAAirBookModifyRQExt>
                    </soap:Body>
                </soap:Envelope>";
        }

        private async Task<string> CallPaymentApiAsync(string soapXml)
        {
            using var client = new HttpClient();
            var content = new StringContent(soapXml, Encoding.UTF8, "text/xml");
            content.Headers.Add("SOAPAction", "http://www.opentravel.org/OTA/2003/05/OTA_AirBookModify");

            var resp = await client.PostAsync(_endpoint, content);
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadAsStringAsync();
        }



        private PaymentSystemGetDto ParsePaymentResponse(XDocument doc)
        {
            XNamespace ns = "http://www.opentravel.org/OTA/2003/05";

            var errors = doc.Descendants(ns + "Error")
                .Select(e => $"{e.Attribute("Code")?.Value}: {e.Attribute("ShortText")?.Value}")
                .ToList();

            if (errors.Any())
            {
                return new PaymentSystemGetDto
                {
                    Status = "error",
                    Error = errors
                };
            }

            var ticketAdvisory = doc.Descendants(ns + "TicketAdvisory").FirstOrDefault()?.Value;

            return new PaymentSystemGetDto
            {
                Status = "success",
                Error = new List<string>(),
                TicketAdvisory = ticketAdvisory 
            };
        }

    }
}
