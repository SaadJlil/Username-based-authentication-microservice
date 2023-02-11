using MediatR;
using Domain.Common.DTOs.Register;
using Application.CQRS.Commands;
using Grpc.Net.Client;
using GrpcAuthServicesClient;
using Domain.Events;


namespace Infrastructure.CQRS_Impl.Commands;

public class RegisterCommandHandler: IRequestHandler<RegisterCommand, RegisterOutputDto>
{
    private readonly theDbContext _context;
    private readonly IMediator _mediatr;
    private readonly AuthServices.AuthServicesClient client;

    public RegisterCommandHandler(theDbContext context, IMediator mediatr)
    {
        _context = context;
        _mediatr = mediatr;
        client = new AuthServices.AuthServicesClient(
            GrpcChannel.ForAddress("http://localhost:5244")
        );
    }

    public async Task<RegisterOutputDto> Handle(RegisterCommand request, CancellationToken token)
    {
            
        
        var reply = client.Register(
            new RegisterInput{
                Username = request.dto.username,
                Password = request.dto.password
            }
        );

        await _mediatr.Publish<RegisterEvent>(new RegisterEvent(
            username: request.dto.username,
            queue: "RegisterQueue"
        ));


        return new RegisterOutputDto(
            username: reply.Username
        );
    } 
}

