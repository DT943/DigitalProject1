namespace BookingEngine.Host.Middleware
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext context)
        {
            var path = context.Request.Path.Value;

            // Define case-insensitive exclusions
            var excludedPaths = new[]
            {
                "/SearchRequest",
                "/AirPort",
                "/Amenity",
                "/Location",
                "/Contact/CreateListPassenger",
                "/Payment/Webhook",
                "/Payment/Checkout",
                "/OnHoldBooking",
                "/InquirePNR/Create",
                "/StripeResult",
                "/AbstractApi/ValidateEmail",
                "/AbstractApi/ValidatePhone",
                "/Reservation",
                "/POS"

            };

            // Also allow /AirPort/{id}
            if (path.StartsWith("/AirPort/", StringComparison.OrdinalIgnoreCase))
            {
                await _next(context);
                return;
            }
            // Also allow /POS/{id}
            if (path.StartsWith("/POS/", StringComparison.OrdinalIgnoreCase))
            {
                await _next(context);
                return;
            }


            if (excludedPaths.Any(p => path.Equals(p, StringComparison.OrdinalIgnoreCase)))
            {
                await _next(context);
                return;
            }

            var user = context.User;
            var tenantClaim = user.FindFirst("tenant_id")?.Value;


            if (tenantClaim != "1")
            {
                context.Response.StatusCode = 403; 
                await context.Response.WriteAsync("Invalid tenant context.");
                return;
            }

            await _next(context);
        }
    }
}
