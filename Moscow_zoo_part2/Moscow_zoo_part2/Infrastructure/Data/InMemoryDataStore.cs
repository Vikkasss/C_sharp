namespace Moscow_zoo_part2.Infrastructure;

public class InMemoryDataStore
{
    public static Dictionary<Guid, object> Data = new Dictionary<Guid, object>();
}