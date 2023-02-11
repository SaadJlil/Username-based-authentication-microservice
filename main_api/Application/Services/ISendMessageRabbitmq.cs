using MassTransit;

namespace Application.Services;


public interface IRabbitmqCommunication<T> where T: notnull
{

    public Task SendMessage(T message, string queue, IBus bus);


}