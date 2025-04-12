namespace Moscow_zoo_part2.Presentation.DTOs;

public class EnclosuredDTO
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public int Size { get; set; }
    public int CurrentCapacity { get; set; }
    public int MaxCapacity { get; set; }
    public List<Guid> Animals { get; set; }
}
