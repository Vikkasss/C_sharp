using FinancialAccounts.Models;
using FinancialAccounts.Services;

namespace FinancialAccount.Patterns.Decorator;

public class LoggingOperationService : IOperationService
{
    private readonly IOperationService _operationService;

    public LoggingOperationService(IOperationService operationService)
    {
        _operationService = operationService;
    }

    public Operation CreateOperation(string type_, int bankAccountId_, decimal amount_, DateTime date_,
        string description_, int categoryId_)
    {
        Console.WriteLine($"Create operation: {type_}, {bankAccountId_}, {amount_}, {date_}, {description_}");
        return _operationService.CreateOperation(type_, bankAccountId_, amount_, date_, description_, categoryId_);
    }

    public void UpdateOperation(int operationId_, string newType, decimal newAmount, DateTime newDate, string newDescription,
        int newCategoryId)
    {
        _operationService.UpdateOperation(operationId_, newType, newAmount, newDate, newDescription, newCategoryId);
    }

    public void DeleteOperation(int operationId_)
    {
        _operationService.DeleteOperation(operationId_);
    }

    public Operation GetOperationById(int operationId)
    {
        return _operationService.GetOperationById(operationId);
    }

    public List<Operation> GetAllOperations()
    {
        return _operationService.GetAllOperations();
    }

    public List<Operation> GetOperationsByAccountId(int bankAccountId)
    {
        return _operationService.GetOperationsByAccountId(bankAccountId);
    }

    public List<Operation> GetOperationsByCategoryId(int categoryId)
    {
        return _operationService.GetOperationsByCategoryId(categoryId);
    }

    public List<Operation> GetOperationsByDateRange(DateTime startDate, DateTime endDate)
    {
        return _operationService.GetOperationsByDateRange(startDate, endDate);
    }

    public void ClearAllOperations()
    {
        _operationService.ClearAllOperations();
    }
}