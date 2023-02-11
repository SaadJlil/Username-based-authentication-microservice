using MassTransit;
using Domain.Events;
using MessageNamespace;
using MediatR;

namespace Infrastructure.Services.RabbitmqConsumers;

public class RegisterConsumer: IConsumer<RegisterMessage>
{
    private IMediator _mediatR;
    public RegisterConsumer(IMediator mediatR)
    {
        _mediatR = mediatR;
    }
    public async Task Consume(ConsumeContext<RegisterMessage> context)
    {        
        await _mediatR.Publish<RegisterEvent>(new RegisterEvent(context.Message));
    }

}

