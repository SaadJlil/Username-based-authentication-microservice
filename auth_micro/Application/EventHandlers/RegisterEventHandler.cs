using Domain.Events;
using MediatR;
using MessageNamespace;
using Application.CQRS.Commands;
using Domain.Common.DTOs.Controllers.Register;

namespace Application.EventHandlers;


public class RegisterEventHandler: INotificationHandler<RegisterEvent>
{
    private readonly IMediator _mediatr;

    public RegisterEventHandler(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    public async Task Handle(RegisterEvent notification, CancellationToken token)
    {
        await _mediatr.Send(new RegisterCommand(
            new RegisterInputDto(
                Username: notification._message.Username,
                Password: notification._message.Password
            )            
        ));
    }
    
}