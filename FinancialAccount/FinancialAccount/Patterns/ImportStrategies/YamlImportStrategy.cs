using FinancialAccounts.Models;
using YamlDotNet.Serialization;

namespace FinancialAccount.Patterns.ImportStrategies;

public class YamlImportStrategy : IImportStrategy
{
    public FinancialData Import(string filePath)
    {
        string yaml = File.ReadAllText(filePath);
        var deserializer = new DeserializerBuilder().Build();
        return deserializer.Deserialize<FinancialData>(yaml);
    }
}