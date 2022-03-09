using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.ApplicationCore.CustomEntities;
using Store.ApplicationCore.Interfaces;
using Store.ApplicationCore.Services;
using Store.Infrastructure.Persistence.Contexts;
using Store.Infrastructure.Persistence.Repositories;
using Microsoft.OpenApi.Models;

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

        public static IServiceCollection AddSwagger(this IServiceCollection services, string xmlFileName)
        {
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Ticketing",
                    Version = "v1",
                });


                doc.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"Esquema de autorizacion. <BR/>
                      Por favor ingresar 'Bearer' [espacio] seguido del token generado en el login.
                      <BR/>Ejemplo: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                doc.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                        },
                        new List<string>()
                      }
                    });


                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                doc.IncludeXmlComments(xmlPath);
            });

            return services;
        }

    }
}
