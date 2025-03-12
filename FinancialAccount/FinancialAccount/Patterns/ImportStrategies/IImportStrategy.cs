using FinancialAccounts.Models;

namespace FinancialAccount.Patterns.ImportStrategies;

public interface IImportStrategy
{
    FinancialData Import(string filePath);
}