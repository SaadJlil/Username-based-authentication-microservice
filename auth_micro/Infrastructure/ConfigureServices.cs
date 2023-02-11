using Microsoft.Extensions.Configuration;
using Grpc.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;
using Infrastructure.Services.RabbitmqConsumers;
using Infrastructure.Services;
using MassTransit;




namespace Program_Configuration;


public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TheContext>(o =>
            o.UseNpgsql(
                configuration.GetConnectionString("test"), 
                b => b.MigrationsAssembly(typeof(TheContext).Assembly.FullName)
            )
        );
        services.AddTransient<Authentication>();



        services.AddMassTransit(x =>
        {
            x.AddConsumer<RegisterConsumer>();
            x.AddConsumer<AuthenticateConsumer>();
            x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host("amqp://whatever:whatever@localhost:5672");

                cfg.ReceiveEndpoint("todoQueue", ep =>
                {
                    ep.ConfigureConsumer<RegisterConsumer>(provider);
                });

                cfg.ReceiveEndpoint("todoQueue1", ep =>
                {
                    ep.ConfigureConsumer<AuthenticateConsumer>(provider);
                });

            }));
        });
        services.AddMassTransitHostedService();


        //grpc
        services.AddGrpc();


        return services;
    }
    
}
