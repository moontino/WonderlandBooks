using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(WonderlandBooks.Web.Areas.Identity.IdentityHostingStartup))]

namespace WonderlandBooks.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
