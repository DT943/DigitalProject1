using AdminLTE.Pages.Gallery;
using AdminLTE.Pages.Gallery.File;
using AdminLTE.Pages.Offer;

namespace AdminLTE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();



            builder.Services.AddHttpClient<OfferModel>();
            builder.Services.AddHttpClient<CreateFlightModel>();
            builder.Services.AddHttpClient<UpdateFlightModel>();
            builder.Services.AddHttpClient<DeleteFlightModel>();
            
            builder.Services.AddHttpClient<GalleryModel>();
			builder.Services.AddHttpClient<UpdateFileModel>();
		    builder.Services.AddHttpClient<CreateFileModel>();
			builder.Services.AddHttpClient<DeleteFileModel>();


			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
