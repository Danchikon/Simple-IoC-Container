namespace IoC.Example;

public class EmailMessageSender : IMessageSender
{
    public Task SendAsync()
    {
        Console.WriteLine("Sending email...");

        return Task.CompletedTask;
    }
}