using MediatR;
using Moscow_zoo_part2.Presentation.DTOs;

namespace Moscow_zoo_part2.Application.Queries;

public class GetAllEnclosureQuery : IRequest<IEnumerable<EnclosuredDTO>>
{
    public string? EnclosureType { get; set; }

    public GetAllEnclosureQuery(string? enlosureType)
    {
        EnclosureType = enlosureType;
    }
}