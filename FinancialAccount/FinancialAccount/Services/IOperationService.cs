using FinancialAccounts.Models;

namespace FinancialAccounts.Services;

public interface IOperationService
{
    Operation CreateOperation(string type_, int bankAccountId_, decimal amount_, DateTime date_, string description_, int categoryId_);
    void UpdateOperation(int operationId_, string newType, decimal newAmount, DateTime newDate, string newDescription, int newCategoryId);
    void DeleteOperation(int operationId_);
    Operation GetOperationById(int operationId);
    List<Operation> GetAllOperations();
    // Получение операций по счету
    List<Operation> GetOperationsByAccountId(int bankAccountId);

    // Получение операций по категории
    List<Operation> GetOperationsByCategoryId(int categoryId);
    List<Operation> GetOperationsByDateRange(DateTime startDate, DateTime endDate);
    void ClearAllOperations();
}