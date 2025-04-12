using MediatR;
using Moscow_zoo_part2.Domain.Entities;
using Moscow_zoo_part2.Presentation.DTOs;

namespace Moscow_zoo_part2.Application.Queries;

public class GetEnclosureQuery : IRequest<IEnumerable<EnclosuredDTO>>
{
    public Guid? EnclousureId { get; set; }

    public GetEnclosureQuery(Guid? enclousureId)
    {
        EnclousureId = EnclousureId;
    }
    
}