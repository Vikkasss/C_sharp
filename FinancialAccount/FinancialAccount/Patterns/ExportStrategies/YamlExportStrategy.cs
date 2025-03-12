using FinancialAccounts.Models;
using YamlDotNet.Serialization;

namespace FinancialAccount.Patterns.Strategy;

public class YamlExportStrategy : IExportStrategy
{
    public void Export(string filePath, FinancialData data)
    {
        var serializer = new Serializer();
        var yaml = serializer.Serialize(data);
        File.WriteAllText(filePath, yaml);
    }
}