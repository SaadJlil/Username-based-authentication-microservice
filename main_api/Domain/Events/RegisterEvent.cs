using MediatR;


namespace Domain.Events;


public class RegisterEvent: INotification
{
    public string _queue { get; set; }
    public string _username { get; set; }
    public RegisterEvent(string username, string queue)
    {
        _username = username;
        _queue = queue;
    }
}