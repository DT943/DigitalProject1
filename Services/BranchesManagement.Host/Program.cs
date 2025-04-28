using BranchesManagement.Data.DbContext;
using BranchesManagement.Host.Helper;
using Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
/*
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Listen(IPAddress.Any, 7130, listenOptions =>
    {
        if (builder.Environment.IsDevelopment())

            listenOptions.UseHttps();
        else

            listenOptions.UseHttps(new X509Certificate2(
                "/etc/letsencrypt/live/reports.chamwings.com/cert.pfx",
                "HappyHappy@2025"));

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
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomService();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Error;
});
/*
builder.Services.AddDbContext<BranchesManagementDbContext>((sp, options) =>
{
    options.UseOracle(string.Format(builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty, Environment.GetEnvironmentVariable("TODOLIST_DB_USER"), Environment.GetEnvironmentVariable("TODOLIST_DB_PASSWORD"))).EnableSensitiveDataLogging() // Enable sensitive data logging for detailed output
           .LogTo(Console.WriteLine, LogLevel.Information); // Log to console;
});
*/
builder.Services.AddDbContext<BranchesManagementDbContext>((sp, options) =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DefaultConnection");

    options.UseSqlServer(connectionString)
           .EnableSensitiveDataLogging()
           .LogTo(Console.WriteLine, LogLevel.Information);
});


builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseCors("AllowAll");

app.ConfigureExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (!app.Environment.IsDevelopment())
    app.UseStaticFiles(new StaticFileOptions
    {
        //FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "images")),
        FileProvider = new PhysicalFileProvider("/applications/images"),
       // RequestPath = "../images" // This maps the '/images' URL path to the directory
    });


app.UseStaticFiles();

app.UseAuthorization();
app.MapControllers();
app.Run();