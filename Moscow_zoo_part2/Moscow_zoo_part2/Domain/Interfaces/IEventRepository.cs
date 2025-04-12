namespace Moscow_zoo_part2.Domain.Interfaces;

public interface IEventRepository
{
    void Publish<TEvent>(TEvent @event) where TEvent : class;
}