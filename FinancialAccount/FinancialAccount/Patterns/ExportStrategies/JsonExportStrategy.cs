using System.Text.Json;
using FinancialAccounts.Models;

namespace FinancialAccount.Patterns.Strategy;

public class JsonExportStrategy : IExportStrategy
{
    public void Export(string filePath, FinancialData data)
    {
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
}