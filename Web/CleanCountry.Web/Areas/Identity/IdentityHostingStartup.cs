using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(CleanCountry.Web.Areas.Identity.IdentityHostingStartup))]

namespace CleanCountry.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}