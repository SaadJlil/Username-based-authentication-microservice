using MassTransit;
using Application.Services;

namespace Infrastructure.Services;


public class RabbitmqCommunication<T> : IRabbitmqCommunication<T>
{
    private readonly IBus _bus;
    private readonly string _queue;

    public RabbitmqCommunication(IBus bus)
    {
        _bus = bus;
    }
    public RabbitmqCommunication(IBus bus, string queue)
    {
        _bus = bus;
        _queue = queue;
    }

    public async Task SendMessage(T message)
    {
        var uri = new Uri($"queue:{_queue}");
        var end_point = await _bus.GetSendEndpoint(uri);
        await end_point.Send(message);
    }

    public async Task SendMessage(T message, string queue, IBus bus)
    {
        var uri = new Uri($"queue:{queue}");
        var end_point = await bus.GetSendEndpoint(uri);
        await end_point.Send(message);
    }
}