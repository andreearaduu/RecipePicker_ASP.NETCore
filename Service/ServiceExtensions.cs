using recipePickerApp.Repository;
using recipePickerApp.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace recipePickerApp.Service
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
