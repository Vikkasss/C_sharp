using MediatR;
using Moscow_zoo_part2.Application.Queries;
using Moscow_zoo_part2.Domain.Entities;
using Moscow_zoo_part2.Domain.Interfaces;
using Moscow_zoo_part2.Presentation.DTOs;

namespace Moscow_zoo_part2.Application.Handlers;

public class GetEnclousureQueryHandler :  IRequestHandler<GetEnclosureQuery, IEnumerable<EnclosuredDTO>>
{
    private readonly IEnclosureRepository _enclosureRepository;

    public GetEnclousureQueryHandler(IEnclosureRepository enclosureRepository)
    {
        _enclosureRepository = enclosureRepository;
    }

    public async Task<IEnumerable<EnclosuredDTO>> Handle(GetEnclosureQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Enclosure> enclosures;
        if (request.EnclousureId.HasValue)
        {
            var enclosure = await _enclosureRepository.GetByIdAsync(request.EnclousureId.Value);
            enclosures = enclosure != null ? new List<Enclosure>() { enclosure } : new List<Enclosure>();
        }
        else
        {
            enclosures = await _enclosureRepository.GetAllAsync();
        }

        return enclosures.Select(a => new EnclosuredDTO
        {
            Id = a.Id,
            Type = a.Type,
            Size = a.Size,
            CurrentCapacity = a.CurrentCapacity,
            MaxCapacity = a.MaxCapacity
        });
    }
}