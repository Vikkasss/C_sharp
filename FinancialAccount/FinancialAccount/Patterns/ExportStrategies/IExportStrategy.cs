using FinancialAccounts.Models;

namespace FinancialAccount.Patterns.Strategy;

public interface IExportStrategy
{
    void Export(string filePath, FinancialData data);
}