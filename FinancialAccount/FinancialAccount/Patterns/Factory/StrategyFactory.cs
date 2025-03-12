using FinancialAccount.Patterns.ImportStrategies;
using FinancialAccount.Patterns.Strategy;

namespace FinancialAccount.Patterns.Factory;

public class StrategyFactory : IStrategyFactory
{
    public IExportStrategy CreateExportStrategy(string format) => format.ToLower() switch
    {
        "json" => new JsonExportStrategy(),
        "yaml" => new YamlExportStrategy(),
        "csv" => new CsvExportStrategy(),
        _ => throw new ArgumentException($"Unsupported export format: {format}")
    };

    public IImportStrategy CreateImportStrategy(string format) => format.ToLower() switch
    {
        "json" => new JsonImportStrategy(),
        "yaml" => new YamlImportStrategy(),
        "csv" => new CsvImportStrategy(),
        _ => throw new ArgumentException($"Unsupported import format: {format}")
    };
}