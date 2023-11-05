using CarWorkshopMVC.Application.Commands.CreateCarWorksop;
using CarWorkshopMVC.Application.Mapping;
using CarWorkshopMVC.Application.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshopMVC.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICarWorkshopService, CarWorkshopService>();
            services.AddAutoMapper(typeof(CarWorkshopMappingProfile));
            services.AddValidatorsFromAssemblyContaining<CreateCarWorkshopCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
            
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CreateCarWorkshopCommand)));

        }
    }
}
