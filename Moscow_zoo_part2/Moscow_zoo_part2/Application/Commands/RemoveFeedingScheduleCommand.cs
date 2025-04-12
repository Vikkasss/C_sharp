using MediatR;

namespace Moscow_zoo_part2.Application.Commands;

public class RemoveFeedingScheduleCommand : IRequest<Unit>
{
    public Guid FeedingShceduleId { get; set; }

    public RemoveFeedingScheduleCommand(Guid id)
    {
        FeedingShceduleId = id;
    }
    
}