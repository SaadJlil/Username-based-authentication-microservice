using Domain.Common.BaseEvents;
using MessageNamespace;

namespace Domain.Events;

public class AuthenticateEvent: BaseEvent
{
    public AuthenticationMessage _message{ get; set; }
    public AuthenticateEvent(AuthenticationMessage message)
    {
        _message = message;
    }

}