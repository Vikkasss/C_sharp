using MediatR;

namespace Moscow_zoo_part2.Application.Commands;

public class AddEnclosureCommand : IRequest<Unit>
{
    public string Type { get; set; }
    public int Size { get; set; }
    public int CurrentCapacity { get; set; }
    public int MaxCapacity { get; set; }

    public AddEnclosureCommand(string type, int size, int currentCapacity, int maxCapacity)
    {
        Type = type;
        Size = size;
        CurrentCapacity = currentCapacity;
        MaxCapacity = maxCapacity;
    }
}