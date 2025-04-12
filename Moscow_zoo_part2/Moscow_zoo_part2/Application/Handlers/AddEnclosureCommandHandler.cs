using MediatR;
using Moscow_zoo_part2.Application.Commands;
using Moscow_zoo_part2.Domain.Entities;
using Moscow_zoo_part2.Domain.Interfaces;

namespace Moscow_zoo_part2.Application.Handlers;

public class AddEnclosureCommandHandler : IRequestHandler<AddEnclosureCommand, Unit>
{
    private readonly IEnclosureRepository _enclosureRepository;

    public AddEnclosureCommandHandler(IEnclosureRepository enclosureRepository)
    {
        _enclosureRepository = enclosureRepository;
    }

    public async Task<Unit> Handle(AddEnclosureCommand request, CancellationToken cancellationToken)
    {
        var enclosure = new Enclosure(request.Type,
            request.Size,
            request.CurrentCapacity,
            request.MaxCapacity);
        await _enclosureRepository.AddAsync(enclosure);
        return Unit.Value;
    }
    
}