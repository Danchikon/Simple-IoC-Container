using IoC.Core;
using IoC.Example;

var container = new Container();

container.RegisterTransient<IMessageSender, EmailMessageSender>();
container.RegisterSingleton<INotifyService, NotifyService>();

var notifyService = container.ResolveRequired<INotifyService>();

await notifyService.NotifyAsync();





