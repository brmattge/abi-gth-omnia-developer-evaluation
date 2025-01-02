namespace Ambev.DeveloperEvaluation.Application.Eventing
{
    public interface IEventPublisher
    {
        Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken) where TEvent : class;
    }
}
