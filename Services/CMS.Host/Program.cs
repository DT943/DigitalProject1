using Microsoft.EntityFrameworkCore;
using System.Text;
using CMS.Host.Helper;
using CMS.Data.DbContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Infrastructure.Service;
 using System.Net;
using CWCore.Data.DbContext;
using System.Security.Cryptography.X509Certificates;



var builder = WebApplication.CreateBuilder(args);
/*
builder.WebHost.ConfigureKestrel(serverOptions =>
{
 
    serverOptions.Listen(IPAddress.Any, 7036, listenOptions =>
    { 
            listenOptions.UseHttps(); 
    });
});
*/

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
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Error;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomService();
/*
builder.Services.AddDbContext<CMSDbContext>((sp, options) =>
{
    options.UseOracle(string.Format(builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty, Environment.GetEnvironmentVariable("TODOLIST_DB_USER"), Environment.GetEnvironmentVariable("TODOLIST_DB_PASSWORD"))).EnableSensitiveDataLogging() // Enable sensitive data logging for detailed output
           .LogTo(Console.WriteLine, LogLevel.Information); // Log to console;

});
*/
/*
builder.Services.AddDbContext<CWDbContext>((sp, options) =>
{
    options.UseOracle(string.Format(builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty, Environment.GetEnvironmentVariable("TODOLIST_DB_USER"), Environment.GetEnvironmentVariable("TODOLIST_DB_PASSWORD"))).EnableSensitiveDataLogging() // Enable sensitive data logging for detailed output
           .LogTo(Console.WriteLine, LogLevel.Information); // Log to console;

});
*/
builder.Services.AddDbContext<CMSDbContext>((sp, options) =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DefaultConnection");

    options.UseSqlServer(connectionString)
           .EnableSensitiveDataLogging()
           .LogTo(Console.WriteLine, LogLevel.Information);
});
builder.Services.AddDbContext<CWDbContext>((sp, options) =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("CWCoreDefaultConnection");

    options.UseSqlServer(connectionString)
           .EnableSensitiveDataLogging()
           .LogTo(Console.WriteLine, LogLevel.Information);
});

builder.Services.AddSwaggerGen();

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseCors("AllowAll");

app.ConfigureExceptionHandler();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseStaticFiles();

app.UseAuthorization();
app.MapControllers();
app.MapRazorPages();

app.Run();
