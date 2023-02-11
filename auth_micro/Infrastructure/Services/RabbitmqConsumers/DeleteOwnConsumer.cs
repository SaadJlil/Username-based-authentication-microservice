using MassTransit;
using Domain.Events;
using MessageNamespace;
using MediatR;

namespace Infrastructure.Services.RabbitmqConsumers;

public class DeleteOwnConsumer: IConsumer<DeleteOwnMessage>
{
    private IMediator _mediatR;
    public DeleteOwnConsumer(IMediator mediatR)
    {
        _mediatR = mediatR;
    }
    public async Task Consume(ConsumeContext<DeleteOwnMessage> context)
    {        
        await _mediatR.Publish<DeleteOwnEvent>(new DeleteOwnEvent(context.Message));
    }

}