using System.Text.Json;
using FinancialAccounts.Models;

namespace FinancialAccount.Patterns.ImportStrategies;

public class JsonImportStrategy : IImportStrategy
{
    public FinancialData Import(string filePath)
    {
        string json = File.ReadAllText(filePath);
        var data = JsonSerializer.Deserialize<FinancialData>(json);
        return data;
    }
}