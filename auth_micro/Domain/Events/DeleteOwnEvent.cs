using MessageNamespace;
using Domain.Common.BaseEvents;


namespace Domain.Events;


public class DeleteOwnEvent: BaseEvent 
{
    public DeleteOwnEvent(DeleteOwnMessage message)
    {
        _message = message;
    }
    public DeleteOwnMessage _message { get; set; }
}