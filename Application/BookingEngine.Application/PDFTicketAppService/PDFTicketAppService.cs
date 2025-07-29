
using PdfSharpCore.Pdf.IO;
using PdfSharpCore.Drawing;
using System.IO;
using BookingEngine.Application.PDFTicketAppService.Dtos;
using Microsoft.AspNetCore.Hosting;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using static System.Runtime.InteropServices.JavaScript.JSType;
using BookingEngine.Application.ExternalServicesAppService.TicketGallary;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Net.Http;
using BookingEngine.Application.PDFTicketAppService;
using UglyToad.PdfPig.Tokens;
using Microsoft.Extensions.Logging;
using System.Reflection.Metadata;
using UglyToad.PdfPig.Graphics;
using Microsoft.EntityFrameworkCore.Metadata;
using BookingEngine.Application.MailModoAppService;

//var document = new PdfSharpCore.Pdf.PdfDocument();

public class PDFTicketAppService : IPDFTicketAppService
{
    private readonly IWebHostEnvironment _env;

    private readonly HttpClient _httpClient;

    private readonly ILogger<PDFTicketAppService> _logger;

    private readonly Dictionary<int, XGraphics> _gfxCache = new();
    
    private readonly IMailModoAppService _mailModoAppService;



    private readonly ICreateTicketPdfFileAppService _createTicketPdfFileAppService;
    public PDFTicketAppService(ILogger<PDFTicketAppService> logger,
        IMailModoAppService mailModoAppService,
        IWebHostEnvironment env, HttpClient httpClient, 
        ICreateTicketPdfFileAppService createTicketPdfFileAppService)
    {
        _env = env;
        _logger = logger;
        _httpClient = httpClient;
        _createTicketPdfFileAppService = createTicketPdfFileAppService;
        _mailModoAppService = mailModoAppService;
    }


    public async Task<string> DownloadPdfAsync(string sessionId, string pnr)
    {

        var pdfUrl = $"https://flycham.com/api/gallery/{sessionId}_{pnr}.pdf";
        var response = await _httpClient.GetAsync(pdfUrl);
        
        response.EnsureSuccessStatusCode(); 

        return pdfUrl;
    }

    public async Task<byte[]> GenerateFromTemplate(PDFTicketCreateDto dto, string stripeAmount, string currency)
    {
        int flightSegment = dto.FlightSegments.Count;
        
        int adultCount = dto.PassengerTicketInfos
            .Count(p => p.PassengerType.Equals("Adult", StringComparison.OrdinalIgnoreCase));

        int childCount = dto.PassengerTicketInfos
            .Count(p => p.PassengerType.Equals("Child", StringComparison.OrdinalIgnoreCase));

        int infantCount = dto.PassengerTicketInfos
            .Count(p => p.PassengerType.Equals("BABY", StringComparison.OrdinalIgnoreCase));

        int isInfant = 0;

        if (infantCount > 0)
        {
            isInfant = 1;
        }

        var templatePath = Path.Combine(_env.WebRootPath, "templates", $"Ticket_{adultCount+childCount}_{flightSegment}_{isInfant}.pdf");

        using var inputStream = File.OpenRead(templatePath);
        using var outputStream = new MemoryStream();

        using var document = PdfReader.Open(inputStream, PdfDocumentOpenMode.Modify);
        
        DrawRightOfPhrase(document, templatePath, "RESERVATION NUMBER (PNR)", dto.PNR);
        DrawRightOfPhrase(document, templatePath, "DATE OF BOOKING", dto.DateOfBooking);


        if (dto.PassengerTicketInfos?.Any() == true)
        {
            var fontSize = GetFontInfoOfPhrase(templatePath, "FLIGHT") ?? 10;
            double lineSpacing = fontSize + 4;
            
            int j = 0;
            int k = 0;

            for (int i = 0; i < dto.PassengerTicketInfos.Count; i++)
            {
                var f = dto.PassengerTicketInfos[i];
                double offsetY = i * lineSpacing * 4; // 4 lines of space per segment
                double offsetYValueKey = offsetY + 2 * lineSpacing;


                double offsetYChild = k * lineSpacing * 4;
                double offsetYChildValueKey = offsetYChild + 2 * lineSpacing;



                double offsetYBABY = j * lineSpacing * 4;       
                double offsetYBABYValueKey = offsetYBABY + 2 * lineSpacing;


                string fullName; 

                if (f.PassengerType == "Adult")
                {
                    fullName = $"{f.PassengerTitle} {f.PassengerFirstName} {f.PassengerLastName}".ToUpper();
                    DrawRightOfPhrase(document, templatePath, "Passenger Name(s)", fullName, xOffset: 0, yOffset: offsetY);

                    DrawRightOfPhrase(document, templatePath, "Fare", $"{f.Fare} {f.FareCurrency}", xOffset: 0, yOffset: offsetY);
                    DrawRightOfPhrase(document, templatePath, "Charges", $"{f.Charges} {f.ChargesCurrency}", xOffset: 0, yOffset: offsetY);
                    DrawRightOfPhrase(document, templatePath, "Paid Amount", $"{f.PaidAmount} {f.PaidAmountCurrency}", xOffset: 0, yOffset: offsetY);
                    DrawRightOfPhrase(document, templatePath, "Balance", $"{f.Balance} {f.BalanceCurrency}", xOffset: 0, yOffset: offsetY);

                    DrawPhraseAndValueRight(document, templatePath, "Passenger Name(s)", "Date Of Birth", f.PassengerDateOfBirth, xOffset: 0, yOffset: offsetYValueKey);
                    DrawPhraseAndValueRight(document, templatePath, "Passenger Name(s)", "Passport No.", "-", xOffset: 0, yOffset: offsetYValueKey + lineSpacing);

                    k += 1;
                
                }
                if (f.PassengerType == "Child")
                {
                    fullName = $"{f.PassengerType}. {f.PassengerFirstName} {f.PassengerLastName}".ToUpper();
                    DrawRightOfPhrase(document, templatePath, "Passenger Name(s)", fullName, xOffset: 0, yOffset: offsetYChild);

                    DrawRightOfPhrase(document, templatePath, "Fare", $"{f.Fare} {f.FareCurrency}", xOffset: 0, yOffset: offsetYChild);
                    DrawRightOfPhrase(document, templatePath, "Charges", $"{f.Charges} {f.ChargesCurrency}", xOffset: 0, yOffset: offsetYChild);
                    DrawRightOfPhrase(document, templatePath, "Paid Amount", $"{f.PaidAmount} {f.PaidAmountCurrency}", xOffset: 0, yOffset: offsetYChild);
                    DrawRightOfPhrase(document, templatePath, "Balance", $"{f.Balance} {f.BalanceCurrency}", xOffset: 0, yOffset: offsetYChild);

                    DrawPhraseAndValueRight(document, templatePath, "Passenger Name(s)", "Date Of Birth", f.PassengerDateOfBirth, xOffset: 0, yOffset: offsetYChildValueKey);
                    DrawPhraseAndValueRight(document, templatePath, "Passenger Name(s)", "Passport No.", "-", xOffset: 0, yOffset: offsetYChildValueKey + lineSpacing);
                    k += 1;

                }
                if (f.PassengerType == "BABY")
                {
                    fullName = $"{f.PassengerType}.{f.PassengerFirstName} {f.PassengerLastName}".ToUpper();
                    DrawRightOfPhrase(document, templatePath, "Infant(s)", fullName, xOffset: 0, yOffset: offsetYBABY);

                    DrawPhraseAndValueRight(document, templatePath, "Infant(s)", "Date Of Birth", f.PassengerDateOfBirth, xOffset: 0, yOffset: offsetYBABYValueKey);
                    DrawPhraseAndValueRight(document, templatePath, "Infant(s)", "Passport No.", "-", xOffset: 0, yOffset: offsetYBABYValueKey + lineSpacing);

                    j += 1;

                }
            }
        }
        DrawAtCoordinatesFromTwoPhrases(
            document,
            templatePath,
            "Fare",         // Use X position of this phrase
            "TOTAL IN USD",        // Use Y position of this phrase
            dto.FareUSD,
            xOffset: 0
        );
        DrawAtCoordinatesFromTwoPhrases(
            document,
            templatePath,
            "Charges",         // Use X position of this phrase
            "TOTAL IN USD",        // Use Y position of this phrase
            dto.ChargesUSD,
            xOffset: 0
        );
        DrawAtCoordinatesFromTwoPhrases(
            document,
            templatePath,
            "Paid Amount",         // Use X position of this phrase
            "TOTAL IN USD",        // Use Y position of this phrase
            dto.PaidAmountUSD,
            xOffset: 0
        );
        DrawAtCoordinatesFromTwoPhrases(
            document,
            templatePath,
            "Balance",         // Use X position of this phrase
            "TOTAL IN USD",        // Use Y position of this phrase
            dto.BalanceUSD,
            xOffset: 0
        );

        // 4. Contact Info
        DrawRightOfPhrase(document, templatePath, "PASSENGER CONTACT DETAILS", $"{dto.ContactFirstName}, {dto.ContactLastName}       {dto.ContactEmail}          {dto.ContactCountryCode}-{dto.ContactAreaCode}-{dto.ContactPhone}", xOffset: 0, yOffset: 0);

        // 5. Flight Segment Info (Only First)
        if (dto.FlightSegments?.Any() == true)
        {
            
            var fontSize = GetFontInfoOfPhrase(templatePath, "FLIGHT") ?? 10;
            double lineSpacing = fontSize + 4;
           
            for (int i = 0; i < dto.FlightSegments.Count; i++)
            {
                var f = dto.FlightSegments[i];
                double offsetY = i * lineSpacing * 4; // 4 lines of space per segment

                double offsetYValueKey = offsetY + lineSpacing * 4;

                DrawRightOfPhrase(document, templatePath, "FLIGHT", f.FlightNumber, xOffset: 0, yOffset: offsetY);
                DrawRightOfPhrase(document, templatePath, "ORIGIN DESTINATION", $"{f.OriginAirPort} \n\n{f.DestinationAirPort} - \n{f.Terminal}", xOffset: 0, yOffset: offsetY);
                DrawRightOfPhrase(document, templatePath, "DEPARTURE / ARRIVAL", $"{f.DepartureDate} {f.DepartureTime} \n\n{f.ArrivalDate} {f.ArrivalTime}", xOffset: 0, yOffset: offsetY);
                DrawRightOfPhrase(document, templatePath, "CHECK-IN FROM", $"{f.CheckInFromDate} {f.CheckInFromTime}", xOffset: 0, yOffset: offsetY);
                DrawRightOfPhrase(document, templatePath, "CLASS OF SERVICE", f.FlightClass, xOffset: 0, yOffset: offsetY);
                DrawRightOfPhrase(document, templatePath, "STATUS", f.Status, xOffset: 0, yOffset: offsetY);

                DrawPhraseAndValueRight(document, templatePath, "ORIGIN DESTINATION", "Duration", f.Duration , xOffset: -10, yOffset: offsetYValueKey);
                DrawPhraseAndValueRight(document, templatePath, "ORIGIN DESTINATION", "Aircraft", f.Aircraft, xOffset: 90, yOffset: offsetYValueKey);
                DrawPhraseAndValueRight(document, templatePath, "ORIGIN DESTINATION", "Transit", "-", xOffset: 190, yOffset: offsetYValueKey);
                DrawPhraseAndValueRight(document, templatePath,"ORIGIN DESTINATION", "Remarks", "-" , xOffset: 280, yOffset: offsetYValueKey);
            }
        }
        if (dto.FareRules?.Any() == true)
        {
            var fontSize = GetFontInfoOfPhrase(templatePath, "Origin / Destination") ?? 10;
            double lineSpacing = fontSize + 4;

            for (int i = 0; i < dto.FareRules.Count; i++)
            {
                var rule = dto.FareRules[i];
                double offsetY = i * lineSpacing * 4; // Enough space for 3 lines per rule

                DrawRightOfPhrase(document, templatePath, "FareRule", "All", xOffset: 0, yOffset: offsetY);
                DrawRightOfPhrase(document, templatePath, "Origin / Destination", rule.Origin_Destination, xOffset: 0, yOffset: offsetY);
                DrawRightOfPhrase(document, templatePath, "Fare Basis Code", rule.FareBasisCode, xOffset: 0, yOffset: offsetY);
               
                var formattedTerms = SplitTextEveryNWords(rule.TermsAndConditions, 12);
                DrawRightOfPhrase(document, templatePath, "Terms and Conditions", formattedTerms, xOffset: 0, yOffset: offsetY);
            }
        }

        document.Save(outputStream, false);

        var pdfBytes = outputStream.ToArray();


        string fileUrl;
        //Gallary 
        try
        {
            var fullName = $"{dto.ContactFirstName} {dto.ContactLastName}";
            fileUrl = await _createTicketPdfFileAppService.UploadFileToGalleryAsync(
                fileBytes: pdfBytes,
                fileName: $"{dto.SessionId}_{dto.PNR}.pdf",
                title: $"ticket {dto.PNR.ToLower()}",
                caption: $"flight ticket for user {fullName.ToLower()}",
                description: "auto-uploaded ticket",
                altText: "flight ticket"
            );
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to upload PDF ticket to gallery for PNR: {PNR}", dto.PNR);
            throw new ApplicationException($"Could not upload PDF ticket for PNR {dto.PNR}", ex);
        }



        // Now send to MailmodoBusiness Class

        if (dto.FlightSegments.Count == 1 && dto.FlightSegments[0].FlightClass == "Economy Class")
        {

            ////Start MailModo
            var variables = new Dictionary<string, string>
            {
                { "Name", $"{dto.ContactFirstName} {dto.ContactLastName}" },
                { "Flight Class", dto.FlightSegments[0].FlightClass },
                { "Business or Economy", dto.FlightSegments[0].FlightClass },

                { "Flight Number", dto.FlightSegments[0].FlightNumber },
                { "PNR", dto.PNR },
                { "Origin", dto.FlightSegments[0].OriginAirPort },               
                { "Destination", dto.FlightSegments[0].DestinationAirPort },
                { "Departure Date", dto.FlightSegments[0].DepartureDate },                
                { "Arrival Date", dto.FlightSegments[0].ArrivalDate },                
                { "Departure Time", dto.FlightSegments[0].DepartureTime },
                { "Arrival Time", dto.FlightSegments[0].ArrivalTime },
                { "Total Fare", stripeAmount},
                { "Currency", currency},
                { "URL", $"https://flycham.com/api/gallery/{dto.SessionId}_{dto.PNR}.pdf" },

            };

            await _mailModoAppService.SendMailmodoEmail(
                recipientEmail: dto.ContactEmail,
                dataVariables: variables,
                CampainName: "CampaignOneWayEconomyBooking"
            );

        }
        else if (dto.FlightSegments.Count == 2 && dto.FlightSegments[0].FlightClass == "Economy Class" && dto.FlightSegments[1].FlightClass == "Economy Class")
        {

            ////Start MailModo
            var variables = new Dictionary<string, string>
            {
                { "Name", $"{dto.ContactFirstName} {dto.ContactLastName}" },
                { "Flight Class", dto.FlightSegments[0].FlightClass },
                { "Business or Economy", dto.FlightSegments[0].FlightClass },

                { "Flight Number first", dto.FlightSegments[0].FlightNumber },
                { "Flight Number sec", dto.FlightSegments[1].FlightNumber },
                { "PNR", dto.PNR },
                { "Origin first", dto.FlightSegments[0].OriginAirPort },
                { "Origin sec", dto.FlightSegments[1].OriginAirPort },
                { "Destination first", dto.FlightSegments[0].DestinationAirPort },
                { "Destination sec", dto.FlightSegments[1].DestinationAirPort },
                { "Departure Date first", dto.FlightSegments[0].DepartureDate },
                { "Departure Date sec", dto.FlightSegments[1].DepartureDate },
                { "Arrival Date first", dto.FlightSegments[0].ArrivalDate },
                { "Arrival Date sec", dto.FlightSegments[1].ArrivalDate },
                { "Departure Time first", dto.FlightSegments[0].DepartureTime },
                { "Departure Time sec", dto.FlightSegments[1].DepartureTime },
                { "Arrival Time first", dto.FlightSegments[0].ArrivalTime },
                { "Arrival Time sec", dto.FlightSegments[1].ArrivalTime },
                { "Total Fare", stripeAmount},
                { "Currency", currency},
                { "URL", $"https://flycham.com/api/gallery/{dto.SessionId}_{dto.PNR}.pdf" },

            };

            await _mailModoAppService.SendMailmodoEmail(
                recipientEmail: dto.ContactEmail,
                dataVariables: variables,
                CampainName: "CampaignRoundTripEconomyBooking"
            );

        }

        else if (dto.FlightSegments.Count == 1 && dto.FlightSegments[0].FlightClass == "Business Class")
        {

            ////Start MailModo
            var variables = new Dictionary<string, string>
            {
                { "Name", $"{dto.ContactFirstName} {dto.ContactLastName}" },
                { "Flight Class", dto.FlightSegments[0].FlightClass },
                { "Business or Economy", dto.FlightSegments[0].FlightClass },

                { "Flight Number", dto.FlightSegments[0].FlightNumber },
                { "PNR", dto.PNR },
                { "Origin", dto.FlightSegments[0].OriginAirPort },
                { "Destination", dto.FlightSegments[0].DestinationAirPort },
                { "Departure Date", dto.FlightSegments[0].DepartureDate },
                { "Arrival Date", dto.FlightSegments[0].ArrivalDate },
                { "Departure Time", dto.FlightSegments[0].DepartureTime },
                { "Arrival Time", dto.FlightSegments[0].ArrivalTime },
                { "Total Fare", stripeAmount},
                { "Currency", currency},
                { "URL", $"https://flycham.com/api/gallery/{dto.SessionId}_{dto.PNR}.pdf" },

            };

            await _mailModoAppService.SendMailmodoEmail(
                recipientEmail: dto.ContactEmail,
                dataVariables: variables,
                CampainName: "CampaignOneWayBusinessBooking"
            );

        }


        else if (dto.FlightSegments.Count == 2 && dto.FlightSegments[0].FlightClass == "Business Class" && dto.FlightSegments[1].FlightClass == "Business Class")
        {

            ////Start MailModo
            var variables = new Dictionary<string, string>
            {
                { "Name", $"{dto.ContactFirstName} {dto.ContactLastName}" },
                { "Flight Class", dto.FlightSegments[0].FlightClass },
                { "Business or Economy", dto.FlightSegments[0].FlightClass },
                { "Flight Number first", dto.FlightSegments[0].FlightNumber },
                { "Flight Number sec", dto.FlightSegments[1].FlightNumber },
                { "PNR", dto.PNR },
                { "Origin first", dto.FlightSegments[0].OriginAirPort },
                { "Origin sec", dto.FlightSegments[1].OriginAirPort },
                { "Destination first", dto.FlightSegments[0].DestinationAirPort },
                { "Destination sec", dto.FlightSegments[1].DestinationAirPort },
                { "Departure Date first", dto.FlightSegments[0].DepartureDate },
                { "Departure Date sec", dto.FlightSegments[1].DepartureDate },
                { "Arrival Date first", dto.FlightSegments[0].ArrivalDate },
                { "Arrival Date sec", dto.FlightSegments[1].ArrivalDate },
                { "Departure Time first", dto.FlightSegments[0].DepartureTime },
                { "Departure Time sec", dto.FlightSegments[1].DepartureTime },
                { "Arrival Time first", dto.FlightSegments[0].ArrivalTime },
                { "Arrival Time sec", dto.FlightSegments[1].ArrivalTime },
                { "Total Fare", stripeAmount},
                { "Currency", currency},
                { "URL", $"https://flycham.com/api/gallery/{dto.SessionId}_{dto.PNR}.pdf" },

            };

            await _mailModoAppService.SendMailmodoEmail(
                recipientEmail: dto.ContactEmail,
                dataVariables: variables,
                CampainName: "CampaignRoundTripBusinessBooking"
            );

        }

        ////End MailModo



        foreach (var gfx in _gfxCache.Values)
        {
            gfx.Dispose();
        }
        _gfxCache.Clear();


        return pdfBytes;
    }

    private void DrawPhraseAndValueRight(PdfSharpCore.Pdf.PdfDocument document,  string templatePath , string anchorPhrase, string phrase, string value, double xOffset, double yOffset)
    {
        var coords = FindPhraseCoordinates(templatePath, anchorPhrase);
        if (coords == null) return;

        var pageIndex = coords.Value.pageIndex;
        var x = coords.Value.x + xOffset;
        var y = coords.Value.y + yOffset;

        var page = document.Pages[pageIndex];
      
        if (!_gfxCache.TryGetValue(pageIndex, out var gfx))
        {
            gfx = XGraphics.FromPdfPage(page);
            _gfxCache[pageIndex] = gfx;
        }

        var fontSize = GetFontInfoOfPhrase(templatePath, anchorPhrase) ?? 10;

        var keyFont = new XFont("Arial", fontSize-2, XFontStyle.Bold);
        var valueFont = new XFont("Arial", fontSize-2, XFontStyle.Regular);
        
        var keyText = $"{phrase}: ";
        var keyWidth = gfx.MeasureString(keyText, keyFont).Width;

        gfx.DrawString(keyText, keyFont, XBrushes.Black, new XRect(x, y, 300, 20), XStringFormats.TopLeft);
        gfx.DrawString(value, valueFont, XBrushes.Black, new XRect(x + keyWidth, y, 300, 20), XStringFormats.TopLeft);

    }


    private double? GetFontInfoOfPhrase(string pdfPath, string phrase)
    {
        using var doc = PdfDocument.Open(pdfPath);
        foreach (var page in doc.GetPages())
        {
            var letters = page.Letters;
            int phraseLength = phrase.Length;

            for (int i = 0; i <= letters.Count - phraseLength; i++)
            {
                bool match = true;
                for (int j = 0; j < phraseLength; j++)
                {
                    if (letters[i + j].Value != phrase[j].ToString())
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                {
                    var first = letters[i];
                    return first.FontSize;
                }
            }
        }
        return null;
    }


    private (double x, double y, int pageIndex)? FindPhraseCoordinates(string pdfPath, string phrase)
    {
        using var doc = PdfDocument.Open(pdfPath);

        foreach (var page in doc.GetPages())
        {
            int phraseLength = phrase.Length;

            for (int i = 0; i <= page.Letters.Count - phraseLength; i++)
            {
                bool match = true;
                for (int j = 0; j < phraseLength; j++)
                {
                    if (!string.Equals(page.Letters[i + j].Value, phrase[j].ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                {
                    var firstLetter = page.Letters[i];

                    using var pdfSharpDoc = PdfReader.Open(pdfPath, PdfDocumentOpenMode.ReadOnly);
                    var pdfSharpPage = pdfSharpDoc.Pages[page.Number - 1];
                    double pageHeight = pdfSharpPage.Height;

                    double correctedY = pageHeight - firstLetter.Location.Y;

                    return (firstLetter.Location.X, correctedY, page.Number - 1); // return pageIndex
                }
            }
        }

        return null;
    }




    private string SplitTextEveryNWords(string text, int wordsPerLine = 9)
    {
        if (string.IsNullOrWhiteSpace(text)) return string.Empty;

        var words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var lines = new List<string>();

        for (int i = 0; i < words.Length; i += wordsPerLine)
        {
            lines.Add(string.Join(" ", words.Skip(i).Take(wordsPerLine)));
        }

        return string.Join("\n", lines);
    }

    private void DrawRightOfPhrase(
    PdfSharpCore.Pdf.PdfDocument document,
    string pdfPath,
    string phrase,
    string value,
    bool bold = false,
    double xOffset = 5,
    double yOffset = -7,
    double width = 200)
    {
        var fontSize = GetFontInfoOfPhrase(pdfPath, phrase) ?? 10;
        var coords = FindPhraseCoordinates(pdfPath, phrase);
        if (coords == null) return;

        var page = document.Pages[coords.Value.pageIndex];
      
        if (!_gfxCache.TryGetValue(coords.Value.pageIndex, out var gfx))
        {
            gfx = XGraphics.FromPdfPage(page);
            _gfxCache[coords.Value.pageIndex] = gfx;
        }

        double x = 0;
        double y = 0; 
        if (coords == null) return;

        var font = new XFont("Arial", fontSize);
        var phraseWidth = gfx.MeasureString(phrase, font).Width;
        if (xOffset == 0)
        {
             x = coords.Value.x ;
            y = coords.Value.y + fontSize + yOffset;
        }
        else
        {
             x = coords.Value.x + phraseWidth + xOffset;
             y = coords.Value.y + yOffset;
        }

        var targetFont = bold ? new XFont("Arial", fontSize, XFontStyle.Bold) : font;

        var lines = value.Split('\n');
        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i].Trim();
            double lineY = y + i * (fontSize + 2);
            gfx.DrawString(line, targetFont, XBrushes.Black, new XRect(x, lineY, width, 20), XStringFormats.TopLeft);
        }
    }

    private void DrawAtCoordinatesFromTwoPhrases(
    PdfSharpCore.Pdf.PdfDocument document,
    string pdfPath,
    string xPhrase,      // phrase to get X from
    string yPhrase,      // phrase to get Y from
    string value,
    bool bold = false,
    double xOffset = 5,
    double yOffset = -7,
    double width = 200)
    {
        var fontSize = GetFontInfoOfPhrase(pdfPath, yPhrase) ?? 10;
        var xCoords = FindPhraseCoordinates(pdfPath, xPhrase);
        var yCoords = FindPhraseCoordinates(pdfPath, yPhrase);
        if (xCoords == null || yCoords == null) return;

        // Ideally both phrases are on the same page. If not, fallback to yPhrase page.
        int pageIndex = (xCoords.Value.pageIndex == yCoords.Value.pageIndex) ? xCoords.Value.pageIndex : yCoords.Value.pageIndex;
        var page = document.Pages[pageIndex];

        if (!_gfxCache.TryGetValue(pageIndex, out var gfx))
        {
            gfx = XGraphics.FromPdfPage(page);
            _gfxCache[pageIndex] = gfx;
        }

        double x = xCoords.Value.x + xOffset;
        double y = yCoords.Value.y + yOffset;

        var font = new XFont("Arial", fontSize);
        var targetFont = bold ? new XFont("Arial", fontSize, XFontStyle.Bold) : font;

        var lines = value.Split('\n');
        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i].Trim();
            double lineY = y + i * (fontSize + 2);
            gfx.DrawString(line, targetFont, XBrushes.Black, new XRect(x, lineY, width, 20), XStringFormats.TopLeft);
        }
    }

}
