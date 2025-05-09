using Moscow_zoo_part2.Domain.Interfaces;

namespace Moscow_zoo_part2.Infrastructure.Repositories;

public class InMemoryEventRepository : IEventRepository
{
    private readonly List<object> _publishedEvents = new List<object>();

    public void Publish<TEvent>(TEvent @event) where TEvent : class
    {
        if (@event == null)
        {
            throw new ArgumentNullException(nameof(@event));
        }
        _publishedEvents.Add(@event);
        Console.WriteLine($"Event published: {@event.GetType().Name}");
    }
    
    public IEnumerable<object> GetPublishedEvents()
    {
        return _publishedEvents;
    }
}