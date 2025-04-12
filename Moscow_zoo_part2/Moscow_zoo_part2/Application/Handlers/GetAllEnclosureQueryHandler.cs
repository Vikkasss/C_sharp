using MediatR;
using Moscow_zoo_part2.Application.Queries;
using Moscow_zoo_part2.Domain.Interfaces;
using Moscow_zoo_part2.Presentation.DTOs;

namespace Moscow_zoo_part2.Application.Handlers;

public class GetAllEnclosureQueryHandler : IRequestHandler<GetAllEnclosureQuery, IEnumerable<EnclosuredDTO>> 
{
    private readonly IEnclosureRepository _enclosureRepository;
    private IRequestHandler<GetAllEnclosureQuery, IEnumerable<EnclosuredDTO>> _requestHandlerImplementation;

    public GetAllEnclosureQueryHandler(IEnclosureRepository enclosureRepository)
    {
        _enclosureRepository = enclosureRepository;
    }

    public async Task<IEnumerable<EnclosuredDTO>> Handle(GetAllEnclosureQuery request,
        CancellationToken cancellationToken)
    {
        var enclosures = await _enclosureRepository.GetAllAsync();
        
        if (!string.IsNullOrEmpty(request.EnclosureType))
        {
            enclosures = enclosures.Where(e => e.Type == request.EnclosureType);
        }
        
        return enclosures.Select(e => new EnclosuredDTO
        {
            Id = e.Id,
            Type = e.Type.ToString(),
            Size = e.Size,
            CurrentCapacity = e.CurrentCapacity,
            MaxCapacity = e.MaxCapacity
        });
    }

}