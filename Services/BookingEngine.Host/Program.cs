using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Infrastructure.Service;
using BookingEngine.Host.Helper;
using BookingEngine.Data.DbContext;
using BookingEngine.Application.ExternalService;
using Audit.Application.Middleware;
using BookingEngine.Host.Middleware;
using Newtonsoft.Json;
using System.Xml;
using Newtonsoft.Json.Linq;
using BookingEngine.Application.OTAUserAppService.Dtos;

//string xml = "    <soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n        <soap:Header>\r\n            <wsse:Security soap:mustUnderstand=\"1\" xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\">\r\n                <wsse:UsernameToken wsu:Id=\"UsernameToken-17099451\" xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\">\r\n                    <wsse:Username>WSALHARAMPAY11</wsse:Username>\r\n                    <wsse:Password Type=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText\">1234pass</wsse:Password>\r\n                </wsse:UsernameToken>\r\n            </wsse:Security>\r\n        </soap:Header>\r\n        <soap:Body xmlns:ns1=\"http://www.isaaviation.com/thinair/webservices/OTA/Extensions/2003/05\" xmlns:ns2=\"http://www.opentravel.org/OTA/2003/05\">\r\n            <ns2:OTA_ReadRQ EchoToken=\"11839640750780-171674061\" PrimaryLangID=\"en-us\" SequenceNmbr=\"1\" TimeStamp=\"2023-02-28T20:00:00\" Version=\"20061.00\">\r\n                <ns2:POS>\r\n                    <ns2:Source TerminalID=\"TestUser/Test Runner\">\r\n                        <ns2:RequestorID ID=\"WSALHARAMPAY\" Type=\"4\"/>\r\n                        <ns2:BookingChannel Type=\"12\"/>\r\n                    </ns2:Source>\r\n                </ns2:POS>\r\n                <ns2:ReadRequests>\r\n                    <ns2:ReadRequest>\r\n                        <ns2:UniqueID ID=\"6Q703\" Type=\"14\"/>\r\n                    </ns2:ReadRequest>\r\n                    <ns2:AirReadRequest>\r\n                        <ns2:DepartureDate>2025-2-28</ns2:DepartureDate>\r\n                    </ns2:AirReadRequest>\r\n                </ns2:ReadRequests>\r\n            </ns2:OTA_ReadRQ>\r\n            <ns1:AAReadRQExt>\r\n                <ns1:AALoadDataOptions>\r\n                    <ns1:LoadTravelerInfo>true</ns1:LoadTravelerInfo>\r\n                    <ns1:LoadAirItinery>true</ns1:LoadAirItinery>\r\n                    <ns1:LoadPriceInfoTotals>true</ns1:LoadPriceInfoTotals>\r\n                    <ns1:LoadFullFilment>true</ns1:LoadFullFilment>\r\n                </ns1:AALoadDataOptions>\r\n            </ns1:AAReadRQExt>\r\n        </soap:Body>\r\n    </soap:Envelope>";
//XmlDocument doc = new XmlDocument();
//doc.LoadXml(xml);
//Da = JObject.Parse(JsonConvert.SerializeXmlNode(doc));


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = false;
    o.SaveToken = false;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
});

builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin() // Allows requests from any origin
                  .AllowAnyMethod()  // Allows any HTTP method (GET, POST, etc.)
                  .AllowAnyHeader(); // Allows any headers
        });
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCustomService();


builder.Services
    .AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Error;
    });


builder.Services.AddDbContext<BookingEngineDbContext>((sp, options) =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DefaultConnection");

    options.UseSqlServer(connectionString)
           .EnableSensitiveDataLogging()
           .LogTo(Console.WriteLine, LogLevel.Information);
});



builder.Services.AddSwaggerGen();

var languageServiceUrl = builder.Configuration["Kestrel:Endpoints:MyHttpEndpoint:Url"];

builder.Services.AddHttpClient<ILanguageApiClient, LanguageApiClient>(client =>
{
    client.BaseAddress = new Uri(languageServiceUrl);
});


var app = builder.Build();

app.UseCors("AllowAll");

app.ConfigureExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseStaticFiles();
//app.UseHttpsRedirection();

app.UseCors("AllowAll");


app.UseAuthentication();

app.UseMiddleware<TenantMiddleware>();

app.UseAuthorization();

app.UseMiddleware<AuditMiddleware>();


app.MapControllers();
app.Run();