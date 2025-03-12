namespace FinancialAccounts.Services;

public class AnalyticsService : IAnalyticsService
{
    private readonly IOperationService operationService;

    public AnalyticsService(IOperationService operationService)
    {
        this.operationService = operationService;
    }

    public decimal CalculateBalanceDifference(DateTime startDate, DateTime endDate)
    {
        var operation = operationService.GetOperationsByDateRange(startDate, endDate);
        decimal totalIncome = operation.Where(o => o.type == "Income").Sum(o => o.amount);

        decimal totalExpense = operation.Where(o => o.type == "Expense").Sum(o => o.amount);
        return totalIncome - totalExpense;
    }

    public Dictionary<string, decimal> GroupOperationsByCategory(DateTime startDate, DateTime endDate)
    {
        var operation = operationService.GetOperationsByDateRange(startDate, endDate);
        var groupedOperations = operation.GroupBy(o => o.category_id).ToDictionary(
            g => g.First().category_id.ToString(),
            g => g.Sum(o => o.amount));
        return groupedOperations;
    }

    public decimal CalculateAverageMonthlyExpense()
    {
        var StartDay = DateTime.Today.AddYears(-1);
        var EndDay = DateTime.Now;
        
        var operations = operationService.GetOperationsByDateRange(StartDay, EndDay);
        var ExpenseOp = operations.
            Where(o => o.type == "Expense").
            ToList();
        decimal totalExpence = ExpenseOp.Sum(o => o.amount);
        int numberofMonths = 12;
        return totalExpence / numberofMonths;
    }

    public decimal CalculateAverageMonthlyIncome()
    {
        var StartDay = DateTime.Today.AddYears(-1);
        var EndDay = DateTime.Now;
        
        var operations = operationService.GetOperationsByDateRange(StartDay, EndDay);
        var incomeOp = operations.
            Where(o => o.type == "Income").
            ToList();
        decimal totalIncome = incomeOp.Sum(o => o.amount);
        int numberofMonths = 12;
        return totalIncome / numberofMonths;
    }
}
