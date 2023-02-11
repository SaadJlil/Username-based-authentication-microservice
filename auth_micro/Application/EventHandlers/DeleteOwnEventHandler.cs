using MediatR;
using Application.CQRS.Commands;
using Domain.Events;


namespace Application.EventHandlers;

public class DeleteOwnEventHandler: INotificationHandler<DeleteOwnEvent>
{
    private readonly IMediator _mediatr;

    public DeleteOwnEventHandler(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    public async Task Handle(DeleteOwnEvent notification, CancellationToken token)
    {
        await _mediatr.Send(new DeleteOwnCommand(notification._message.JwtToken));
    }
}