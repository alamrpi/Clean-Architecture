using BuberDinner.Api.Common.Mapping;
using BuberDinner.Api.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;
namespace BuberDinner.Application
{
    public static class DepedencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            //builder.Services.AddControllers(opt =>
            //{
            //    opt.Filters.Add<ErrorHandlingFilterAttribute>();
            //});
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddMappings();
            return services;
        }
    }
}
