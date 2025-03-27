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
Console.WriteLine("Application is starting V.1.3");


var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options =>
{
    options.Listen(IPAddress.Any, 7189); // HTTP port
    options.Listen(IPAddress.Any, 7182, listenOptions =>
    {
        listenOptions.UseHttps();  // HTTPS port
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
    options.Lockout.MaxFailedAccessAttempts = 5; // Lock account after 5 failed attempts
    options.Lockout.AllowedForNewUsers = true; // Enable lockout for new users
});



var app = builder.Build();

app.UseCors("AllowAll"); // Apply CORS policy

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
