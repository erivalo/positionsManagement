using Management.Service.Infrastructure.EventBus;

namespace Management.Service.IntegrationEvents;
public record PositionCreatedEvent(string positionId) : Event;