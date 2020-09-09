using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(recipePickerApp.Areas.Identity.IdentityHostingStartup))]
namespace recipePickerApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });

            // Uncomment the following lines to enable logging in with third party login providers
        }
    }
}