using FinancialAccount.Patterns.ImportStrategies;
using FinancialAccount.Patterns.Strategy;

namespace FinancialAccount.Patterns.Factory;

public interface IStrategyFactory
{
    IExportStrategy CreateExportStrategy(string format);
    IImportStrategy CreateImportStrategy(string format);
}