using MediatR;
using Domain.Events;
using Application.Services;
using MessageNamespace;
using MassTransit;


namespace Application.EventsHandlers;

public class RegisterEventHandler: INotificationHandler<RegisterEvent>
{
    private readonly IBus _bus;
    private readonly IRabbitmqCommunication<RegisteredMessage> _rabbit;
    public RegisterEventHandler(IBus bus, IRabbitmqCommunication<RegisteredMessage> rabbit)
    {

       _rabbit = rabbit;
       _bus = bus;
    }

    public async Task Handle(RegisterEvent notification, CancellationToken token)
    {
        await _rabbit.SendMessage(new RegisteredMessage(
            Username: notification._username 
        ), notification._queue, _bus);
    }

}