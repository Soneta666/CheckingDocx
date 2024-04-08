using Core.Interfaces;
using Core.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class ServiceExtensions
    {
        public static void AddMapster(this IServiceCollection services)
        {
            //var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            //services.AddSingleton(assemblies);
            services.AddSingleton<IMapper, Mapper>();
        }
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        }
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IRequirementsService, RequirementsService>();
            services.AddScoped<IValuesService, ValuesService>();
        }
    }
}
