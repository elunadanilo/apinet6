using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Store.Infrastructure.Filters;

namespace Store.Infrastructure
{
    public static class ConfigureService
    {
        public static IServiceCollection ConfigureFluentValidation(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });

            return services;
        }
    }
}
