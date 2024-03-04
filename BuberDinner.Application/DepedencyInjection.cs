using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using BuberDinner.Application.Common.Behaviors;
using FluentValidation;
namespace BuberDinner.Application
{
    public static class DepedencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
