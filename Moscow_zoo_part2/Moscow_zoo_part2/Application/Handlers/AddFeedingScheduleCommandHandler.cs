using MediatR;
using Moscow_zoo_part2.Application.Commands;
using Moscow_zoo_part2.Domain.Entities;
using Moscow_zoo_part2.Domain.Interfaces;

namespace Moscow_zoo_part2.Application.Handlers;

public class AddFeedingScheduleCommandHandler : IRequestHandler<AddFeedingScheduleCommand, Unit>
{
    private readonly IFeedingScheduleRepository _feedingScheduleRepository;

    public AddFeedingScheduleCommandHandler(IFeedingScheduleRepository feedingScheduleRepository)
    {
        _feedingScheduleRepository = feedingScheduleRepository;
    }

    public async Task<Unit> Handle(AddFeedingScheduleCommand request, CancellationToken cancellationToken)
    {
        var feedingschedule = new FeedingSchedule(request.AnimalId,
            request.FeedingDate,
            request.FoodType);
        await _feedingScheduleRepository.AddAsync(feedingschedule);
        return Unit.Value;
    }
}