using MediatR;
using Moscow_zoo_part2.Application.Queries;
using Moscow_zoo_part2.Domain.Entities;
using Moscow_zoo_part2.Domain.Interfaces;

namespace Moscow_zoo_part2.Application.Handlers;

public class GetFeedingScheduleHandler : IRequestHandler<GetFeedingSchedules, IEnumerable<FeedingSchedule>>
{
    private readonly IFeedingScheduleRepository _feedingScheduleRepository;

    public GetFeedingScheduleHandler(IFeedingScheduleRepository feedingScheduleRepository)
    {
        _feedingScheduleRepository = feedingScheduleRepository;
    }
    public async Task<IEnumerable<FeedingSchedule>> Handle(GetFeedingSchedules request, CancellationToken cancellationToken)
    {
        var feedingSchedule = await _feedingScheduleRepository.GetAllAsync();
        return feedingSchedule;
    }
}