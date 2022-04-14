using Application.Common.Context;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<SqliteDbContext>(options => options.UseSqlite("Data Source=Energomera.db"));
            services.AddScoped<IDbContext>(provider => provider.GetService<SqliteDbContext>());

            return services;
        }
    }
}