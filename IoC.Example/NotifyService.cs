namespace IoC.Example;

public class NotifyService : INotifyService
{
    private readonly IMessageSender _messageSender;
    public NotifyService(IMessageSender messageSender)
    {
        _messageSender = messageSender;
    }

    public Task NotifyAsync() => _messageSender.SendAsync();
}