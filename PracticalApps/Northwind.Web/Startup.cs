using West.Shared; // AddNorthwindContext extention method

namespace Northwind.Web;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
        services.AddNorthwindContext();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // middleware extension methods (work between browser and web site)
        // (Run, Use, Map):
        if (!env.IsDevelopment())
        {
            app.UseHsts();
        }
        
        app.UseRouting(); // start endpoint routing

        // custom middleware delegate
        app.Use(async (HttpContext context, Func<Task> next) =>
        {
            RouteEndpoint? rep = context.GetEndpoint() as RouteEndpoint;
            if (rep is not null)
            {
                Console.WriteLine($"Endpoint name: {rep.DisplayName}");
                Console.WriteLine($"Endpoint route pattern: {rep.RoutePattern.RawText}");
            }
            if (context.Request.Path == "/bonjour")
            {
                // in the case of a match on URL path, this becomes a terminating
                // delegate that returns so does not call the next delegate
                await context.Response.WriteAsync("Bonjour Monde!");
                return;
            }
            // we could modify the request before calling the next delegate
            await next();
            // we could modify the response after calling the next delegate
        });

        app.UseHttpsRedirection(); // redirect http -> https

        app.UseDefaultFiles(); // index.html, default.html, and so on
        app.UseStaticFiles(); // looks in wwwroot for static files

        app.UseEndpoints(endpoints => // adds middleware to execute
        {
            endpoints.MapRazorPages(); // URL/suppliers -> Pages/suppliers.cshtml
            endpoints.MapGet("/hello", () => "Follow the white rabbit");
        });
    }
}