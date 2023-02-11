using MassTransit;
using Domain.Events;
using MessageNamespace;
using MediatR;

namespace Infrastructure.Services.RabbitmqConsumers;

public class AuthenticateConsumer: IConsumer<AuthenticationMessage>
{
    private IMediator _mediatR;
    public AuthenticateConsumer(IMediator mediatR)
    {
        _mediatR = mediatR;
    }
    public async Task Consume(ConsumeContext<AuthenticationMessage> context)
    {
        await _mediatR.Publish<AuthenticateEvent>(new AuthenticateEvent(context.Message));
    }

}

