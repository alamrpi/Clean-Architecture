
using BuberDinner.Api.Common.Errors;
using BuberDinner.Api.Filters;
using BuberDinner.Api.Middleware;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BuberDinner.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            {
                //builder.Services.AddControllers(opt =>
                //{
                //    opt.Filters.Add<ErrorHandlingFilterAttribute>();
                //});
                builder.Services.AddControllers();
                builder.Services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
                builder.Services
                    .AddApplication()
                    .AddInfrastructure(builder.Configuration);
            }

            var app = builder.Build();
            {
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseExceptionHandler("/error");

                //For custom property in problem details
                //app.Map("/error", (HttpContext httpContext) =>
                //{
                //    Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature?>()?.Error;
                //    return Results.Problem();
                //});
                //app.UseMiddleware<ErrorHandlingMiddleware>();
                app.UseHttpsRedirection();

                //app.UseAuthorization();

                app.MapControllers();

                app.Run();
            }
        }
    }
}
