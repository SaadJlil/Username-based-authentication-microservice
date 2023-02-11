using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Services;
using MediatR;
using System.Reflection;
using Application.Services;


namespace Infrastructure;


public static class ConfiguteServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration conf)
    {
        services.AddDbContext<theDbContext>(o =>
            o.UseNpgsql(
                conf.GetConnectionString("test"), 
                b => b.MigrationsAssembly(typeof(theDbContext).Assembly.FullName)
            )
        );

        

        //Add Mediator
        services.AddMediatR(Assembly.GetExecutingAssembly());



        //Service dependency injection
        services.AddScoped(typeof(IRabbitmqCommunication<>), typeof(RabbitmqCommunication<>));



        return services;
    }

}