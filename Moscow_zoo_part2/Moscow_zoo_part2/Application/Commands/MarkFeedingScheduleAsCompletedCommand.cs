using MediatR;

namespace Moscow_zoo_part2.Application.Commands;

public class MarkFeedingScheduleAsCompletedCommand : IRequest<Unit>
{
    public Guid FeedingScheduleId { get; set; }

    public MarkFeedingScheduleAsCompletedCommand(Guid feedingScheduleId)
    {
        FeedingScheduleId = feedingScheduleId;
    }
}