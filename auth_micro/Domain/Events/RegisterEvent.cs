using Domain.Common.BaseEvents;
using MessageNamespace;
using MediatR;

namespace Domain.Events;

public class RegisterEvent: BaseEvent 
{
    public RegisterMessage _message{ get; set; }
    public RegisterEvent(RegisterMessage message)
    {
        _message = message;
    }

}