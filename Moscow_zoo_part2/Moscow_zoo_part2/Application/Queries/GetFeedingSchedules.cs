using MediatR;
using Moscow_zoo_part2.Domain.Entities;

namespace Moscow_zoo_part2.Application.Queries;

public class GetFeedingSchedules : IRequest<IEnumerable<FeedingSchedule>>
{
    
}