using MediatR;


//Cryptography
using System.Security.Cryptography;

//Jwt auth 
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

//Notification Handlers
using Application.EventHandlers;

//For Dependency injections (INotification Handlers)
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Infrastructure.CQRS_impl.Commands;


//Assembly dependency
using System.Reflection;


namespace Program_Configuration;


public static class ConfigureServices
{
    public static WebApplicationBuilder ConfigureServices_methd(this WebApplicationBuilder builder, IConfiguration configuration)
    {
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




        //MediatR Configuration
        //Add Infrastructure (where mediatr handlers are) assembly to mediatr
        builder.Services.AddMediatR(Assembly.Load("Infrastructure"));



        //Asymetric Jwt authentication  
        builder.Services.AddAuthentication()
                .AddJwtBearer("Asymmetric", options => {
                    RSA rsa = RSA.Create();
                    rsa.ImportRSAPublicKey(
                        source: Convert.FromBase64String(builder.Configuration.GetSection("Jwt").GetSection("Public_Key").Value),
                        bytesRead: out int _
                    );
                    
                    options.IncludeErrorDetails = true; // <- great for debugging

                    // Configure the actual Bearer validation
                    options.TokenValidationParameters = new TokenValidationParameters {
                        IssuerSigningKey = new RsaSecurityKey(rsa),
                        ValidIssuer = builder.Configuration.GetSection("Jwt").GetSection("Issuer").Value,
                        ValidAudience = builder.Configuration.GetSection("Jwt").GetSection("Audience").Value,
                        RequireSignedTokens = true,
                        RequireExpirationTime = true, 
                        ValidateLifetime = true, 
                        ValidateAudience = true,
                        ValidateIssuer = true,
                    };
                });

        return builder;
    }
    
}





//Notes:

/*

*******  Adding one handler  ********
builder.Host.ConfigureContainer<ContainerBuilder>(b => b.RegisterAssemblyTypes(typeof(testeventhandler)
  .GetTypeInfo().Assembly)
  .AsClosedTypesOf(typeof(INotificationHandler<>)));



*******  Adding multiple handlers  *********

var List_Handlers = new List<string>{"testeventhandler", "RegisterEventHandler"};
        string handlers_namespace = "Application.EventHandlers";
    
        var HandlersTypes = Assembly.Load("Application").GetTypes().Where(x => 
            x.FullName.Substring(0, handlers_namespace.Length) == handlers_namespace && List_Handlers.Any(h => h == x.Name));

builder.Host.ConfigureContainer<ContainerBuilder>(b => 
    {
        foreach(var handler in HandlersTypes)
        {
            b.RegisterAssemblyTypes(handler
                .GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(INotificationHandler<>));
        }
    }
);


*/


//Adding Authentification jwt "Symetric
        /*
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidIssuer = builder.Configuration.GetSection("Jwt").GetSection("Issuer").Value,
                ValidAudience = builder.Configuration.GetSection("Jwt").GetSection("Audience").Value,
                ValidateLifetime = true,
                RequireExpirationTime = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt").GetSection("Key").Value)),
                ClockSkew = TimeSpan.Zero
            };
        });
        */
          