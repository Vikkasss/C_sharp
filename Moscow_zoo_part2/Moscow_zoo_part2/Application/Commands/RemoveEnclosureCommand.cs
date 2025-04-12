using MediatR;

namespace Moscow_zoo_part2.Application.Commands;

public class RemoveEnclosureCommand : IRequest<Unit>
{
    public Guid EnclosureId { get; set; }

    public RemoveEnclosureCommand(Guid enclosureid)
    {
        EnclosureId = enclosureid;
    }
}