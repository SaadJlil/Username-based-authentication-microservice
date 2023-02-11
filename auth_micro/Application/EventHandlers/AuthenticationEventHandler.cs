using Domain.Events;
using MediatR;
using MessageNamespace;
using Application.CQRS.Commands;
using Domain.Common.DTOs.Controllers.Register;

namespace Application.EventHandlers;


public class AuthenticateEventHandler: INotificationHandler<AuthenticateEvent>
{
    private readonly IMediator _mediatr;

    public AuthenticateEventHandler(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    public async Task Handle(AuthenticateEvent notification, CancellationToken token)
    {
        await _mediatr.Send(new AuthenticationCommand(
            new RegisterInputDto(
                Username: notification._message.Username,
                Password: notification._message.Password
            )            
        ));
    }
    
}