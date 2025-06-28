namespace BookingEngine.Host.Middleware
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext context)
        {
            var path = context.Request.Path.Value;

            // Exclude /SearchRequest (case-insensitive match)
            if (path.Equals("/SearchRequest", StringComparison.OrdinalIgnoreCase))
            {
                await _next(context); // skip tenant check
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
