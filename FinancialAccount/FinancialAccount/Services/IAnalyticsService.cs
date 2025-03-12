namespace FinancialAccounts.Services;

public interface IAnalyticsService
{
    decimal CalculateBalanceDifference(DateTime startDate, DateTime endDate);
    
    Dictionary<string, decimal> GroupOperationsByCategory(DateTime startDate, DateTime endDate);
    
    decimal CalculateAverageMonthlyExpense();
    decimal CalculateAverageMonthlyIncome();
}