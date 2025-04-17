using Authentication.Data.DbContext;
using Authentication.Domain.Models;
using Authentication.Host.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Net;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.ConstrainedExecution;
Console.WriteLine("Application is starting V.1.9.1");


var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Listen(IPAddress.Any, 7189); // HTTP

    serverOptions.Listen(IPAddress.Any, 7182, listenOptions =>
    {
        if (builder.Environment.IsDevelopment())
        
            listenOptions.UseHttps(); 
        else
        
            listenOptions.UseHttps(new X509Certificate2(
                "/etc/letsencrypt/live/reports.chamwings.com/cert.pfx",
                "HappyHappy@2025"));
        
    });
});

// Add services to the container.
builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o => {
    o.RequireHttpsMetadata = false;
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization(//options =>
//{ options.AddPolicy("SuperAdmin", policy => policy.RequireRole("SuperAdmin"));}
);

builder.Services
    .AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Error;
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


builder.Logging.AddConsole();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomService();
builder.Services.AddDbContext<ApplicationDbContext>((sp, options) =>
{
    options.UseOracle(string.Format(builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty, Environment.GetEnvironmentVariable("TODOLIST_DB_USER"), Environment.GetEnvironmentVariable("TODOLIST_DB_PASSWORD"))).EnableSensitiveDataLogging() // Enable sensitive data logging for detailed output
           .LogTo(Console.WriteLine, LogLevel.Information); // Log to console;

});
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Debug); // Make sure the level is low enough to show "Information" logs


builder.Services.Configure<IdentityOptions>(options =>
{
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1); // Lock account for 1 minutes
    options.Lockout.MaxFailedAccessAttempts = 3; // Lock account after 5 failed attempts
    options.Lockout.AllowedForNewUsers = true; // Enable lockout for new users
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");

app.UseHttpsRedirection();

// Important: Authentication must come before Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
