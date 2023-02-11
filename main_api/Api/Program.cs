using Infrastructure;
using MassTransit;
using System.Reflection;


using Application.Services;
using Infrastructure.Services;




//For Dependency injections (INotification Handlers)
using Autofac;
using Autofac.Extensions.DependencyInjection;


//Event
using Domain.Events;


//Event handler
using Application.EventsHandlers;

//Mediatr
using MediatR;

//exp
using Infrastructure.CQRS_Impl.Commands;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Adding INotification handling dependencies 
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(b => 
    b.RegisterAssemblyTypes(typeof(RegisterEventHandler)
        .GetTypeInfo().Assembly)
        .AsClosedTypesOf(typeof(INotificationHandler<>))
);

builder.Host.ConfigureContainer<ContainerBuilder>(b => 
    b.RegisterAssemblyTypes(typeof(RegisterCommandHandler)
        .GetTypeInfo().Assembly)
        .AsClosedTypesOf(typeof(IRequestHandler<>))
);

builder.Host.ConfigureContainer<ContainerBuilder>(b => 
    b.RegisterAssemblyTypes(typeof(RabbitmqCommunication<>)
        .GetTypeInfo().Assembly)
        .AsClosedTypesOf(typeof(IRabbitmqCommunication<>))
);





//Add Masstransit 
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host("amqp://whatever:whatever@localhost:5672/");

    });
});
builder.Services.AddMassTransitHostedService();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
