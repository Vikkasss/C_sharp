using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using FinancialAccounts.Models;

namespace FinancialAccount.Patterns.Strategy;

public class CsvExportStrategy : IExportStrategy
{
    public void Export(string filePath, FinancialData data)
    {
        ExportEntities(Path.Combine(filePath, "accounts.csv"), data.Accounts);
        ExportEntities(Path.Combine(filePath, "categories.csv"), data.Categories);
        ExportEntities(Path.Combine(filePath, "operations.csv"), data.Operations);
    }
    private void ExportEntities<T>(string filepath, IEnumerable<T> entities)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";"
        };
        using var writer = new StreamWriter(filepath);
        using var csv = new CsvWriter(writer, config);
        
        csv.WriteRecords(entities);
    }
}