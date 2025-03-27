using RabbitMQ.Client;

namespace Management.Service.Infrastructure.RabbitMq;
public interface IRabbitMqConnection
{
  IConnection Connection { get; }
}