using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Data;

namespace WebApi.Infrastructure.Configuration
{
    public static class ConfigurationService
    {
        public static void RegisterContextDb(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<WebApiContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionString"),
                options => options.MigrationsAssembly(typeof(WebApiContext).Assembly.FullName)));  
        }
    }
}
