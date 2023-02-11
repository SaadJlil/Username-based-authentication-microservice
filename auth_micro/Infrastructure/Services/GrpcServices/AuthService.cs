using Grpc.Core;
using GrpcAuthServices.Protos;
using static GrpcAuthServices.Protos.AuthServices;
using Application.CQRS.Commands;
using MediatR;
using Domain.Common.DTOs.Controllers.Register;


namespace Infrastructure.Services.GrpcServices;

public class AuthGrpc: AuthServicesBase
{
    private readonly IMediator _mediatr;
    public AuthGrpc(IMediator mediatr)
    {
        _mediatr = mediatr;
    }
    public override async Task<Jwt> Authenticate(AuthenticationInput request, ServerCallContext context)
    {
        return new Jwt{
                    JwtString = await _mediatr.Send(new AuthenticationCommand(
                    new RegisterInputDto(request.Username, request.Password)
                )
            )
        };
    }
    public override async Task<RegisterOutput> Register(RegisterInput request, ServerCallContext context)
    {
        var user = await _mediatr.Send(new RegisterCommand(
            new RegisterInputDto(
                Username: request.Username,
                Password: request.Password
            )
        ));

        return new RegisterOutput{
            Username = user.Username 
        };
    }
    public override async Task<DeleteOwnOutput> DeleteOwn(DeleteOwnInput request, ServerCallContext context)
    {
        return new DeleteOwnOutput{
            Result = await _mediatr.Send(new DeleteOwnCommand(request.Token)) ?? false
        };
    }
}