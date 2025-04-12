using MediatR;
using Microsoft.AspNetCore.Http.Features;
using Moscow_zoo_part2.Application.Commands;
using Moscow_zoo_part2.Domain.Interfaces;

namespace Moscow_zoo_part2.Application.Handlers;

public class MarkFeedingScheduleAsCompletedCommandHandler : IRequestHandler<MarkFeedingScheduleAsCompletedCommand, Unit>
{
    private readonly IFeedingScheduleRepository _feedingScheduleRepository;

    public MarkFeedingScheduleAsCompletedCommandHandler(IFeedingScheduleRepository feedingScheduleRepository)
    {
        _feedingScheduleRepository = feedingScheduleRepository;
    }
    public async Task<Unit> Handle(MarkFeedingScheduleAsCompletedCommand request, CancellationToken cancellationToken)
    {
        var schedule = await _feedingScheduleRepository.GetByIdAsync(request.FeedingScheduleId);
        schedule.MarkAsCompleted();
        await _feedingScheduleRepository.UpdateAsync(schedule);
        return Unit.Value;
    }
}