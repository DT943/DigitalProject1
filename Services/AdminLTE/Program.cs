using AdminLTE.Pages.Gallery;
using AdminLTE.Pages.Gallery.File;
using AdminLTE.Pages.Offer;
using AdminLTE.Pages.Page;
using AdminLTE.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;

Console.WriteLine("Application is starting V.1.3");


var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.Listen(IPAddress.Any, 7107, listenOptions =>
    {
        listenOptions.UseHttps();  // HTTPS port
    });
});
//Lubna
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});



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


// Add services to the container.
builder.Services.AddRazorPages();




builder.Services.AddHttpClient<OfferModel>();
builder.Services.AddHttpClient<CreateFlightModel>();
builder.Services.AddHttpClient<UpdateFlightModel>();
builder.Services.AddHttpClient<DeleteFlightModel>();


builder.Services.AddHttpClient(); // Register the factory first
builder.Services.AddScoped<HttpClientService>(); // Register your service


builder.Services.AddHttpClient<GalleryModel>();
builder.Services.AddHttpClient<CreateFileModel>();
builder.Services.AddHttpClient<DeleteFileModel>();

builder.Services.AddHttpClient<PagesModel>();


builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddCustomService();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
