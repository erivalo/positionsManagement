namespace Management.Service.Infrastructure.EventBus.Abstractions;
public interface IEventBus
{
  Task PublishAsync(Event @event);
}