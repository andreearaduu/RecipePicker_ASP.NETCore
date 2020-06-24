using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using recipePickerApp.DataContext;

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