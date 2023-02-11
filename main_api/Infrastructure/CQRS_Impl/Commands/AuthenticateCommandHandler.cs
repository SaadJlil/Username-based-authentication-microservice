using MediatR;
using Application.CQRS.Commands;
using Grpc.Net.Client;
using GrpcAuthServicesClient;
using Domain.Events;
using System.Threading.Tasks;





namespace Infrastructure.CQRS_Impl.Commands;

public class AuthenticateCommandHandler: IRequestHandler<AuthenticationCommand, string?>
{
    private readonly AuthServices.AuthServicesClient client;
    private readonly IMediator _mediatr;
    public AuthenticateCommandHandler(IMediator mediatr)
    {
        client = new AuthServices.AuthServicesClient(
            GrpcChannel.ForAddress("http://localhost:5244")
        );
        _mediatr = mediatr;
    }

    public async Task<string?> Handle(AuthenticationCommand request, CancellationToken token)
    {
        var reply = await client.AuthenticateAsync(
            new AuthenticationInput{ 
                Username = request.dto.username,
                Password = request.dto.password 
            }
        );

        
        return reply.JwtString;
    }
}
