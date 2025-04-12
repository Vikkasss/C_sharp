using MediatR;
using Moscow_zoo_part2.Application.Commands;
using Moscow_zoo_part2.Domain.Interfaces;

namespace Moscow_zoo_part2.Application.Handlers;

public class RemoveFeedingScheduleCommandHandler : IRequestHandler<RemoveFeedingScheduleCommand, Unit>
{
    private readonly IFeedingScheduleRepository _feedingScheduleRepository;

    public RemoveFeedingScheduleCommandHandler(IFeedingScheduleRepository feedingScheduleRepository)
    {
        _feedingScheduleRepository = feedingScheduleRepository;
    }

    public async Task<Unit> Handle(RemoveFeedingScheduleCommand request, CancellationToken cancellationToken)
    {
        await _feedingScheduleRepository.DeleteAsync(request.FeedingShceduleId);
        return Unit.Value;
    }
}