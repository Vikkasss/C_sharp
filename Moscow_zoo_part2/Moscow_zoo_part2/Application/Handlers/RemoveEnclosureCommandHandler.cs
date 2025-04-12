using MediatR;
using Moscow_zoo_part2.Application.Commands;
using Moscow_zoo_part2.Domain.Interfaces;

namespace Moscow_zoo_part2.Application.Handlers;

public class RemoveEnclosureCommandHandler : IRequestHandler<RemoveEnclosureCommand, Unit>
{
    private readonly IEnclosureRepository _enclosureRepository;

    public RemoveEnclosureCommandHandler(IEnclosureRepository enclosureRepository)
    {
        _enclosureRepository = enclosureRepository;
    }

    public async Task<Unit> Handle(RemoveEnclosureCommand request, CancellationToken cancellationToken)
    {
        await _enclosureRepository.DeleteAsync(request.EnclosureId);
        return Unit.Value;
    }
}