using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.ApplicationCore.CustomEntities;
using Store.ApplicationCore.Interfaces;
using Store.ApplicationCore.Services;
using Store.Infrastructure.Persistence.Contexts;
using Store.Infrastructure.Persistence.Repositories;

namespace Store.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var defaultConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<StoreContext>(options =>
               options.UseSqlServer(defaultConnectionString));

            services.AddTransient<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            

            return services;
        }
        public static IServiceCollection AddPagination(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PaginationOptions>(options => configuration.GetSection("Pagination").Bind(options));

            return services;
        }

    }
}
