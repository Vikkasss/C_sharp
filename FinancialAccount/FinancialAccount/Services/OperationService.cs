using FinancialAccounts.Models;

namespace FinancialAccounts.Services;

public class OperationService : IOperationService
{
    private List<Operation> operations = new();
    private int operationsId = 1;

    public OperationService()
    {
        operations = new List<Operation>();
    }
    
    public Operation CreateOperation(string type_, int bankAccountId_, decimal amount_, DateTime date_, string description_, int categoryId_)
    {
        // Добавляем валидацию типа
        if (type_ != "Expense" && type_ != "Income")
        {
            throw new ArgumentException("Invalid operation type. Allowed: 'Expense' or 'Income'");
        }
        if (string.IsNullOrWhiteSpace(type_))
        {
            throw new ArgumentException("Invalid operation type");
        }

        if (string.IsNullOrWhiteSpace(description_))
        {
            throw new ArgumentException("Invalid operation description");
        }

        if (categoryId_ == 0)
        {
            throw new ArgumentException("Invalid category_id");
        }

        if  (amount_ == 0 ||bankAccountId_ == 0)
        {
            throw new ArgumentException("Invalid bank account or amount");
        }

        var newOperation = new Operation()
        {
            id = operationsId++,
            type = type_,
            bankAccountId = bankAccountId_,
            amount = amount_,
            date = date_,
            description = description_,
            category_id = categoryId_
        };
        operations.Add(newOperation);
        return newOperation;
    }

    public void UpdateOperation(int operationId_, string newType, decimal newAmount, DateTime newDate, string newDescription,
        int newCategoryId)
    {
        var operation = operations.FirstOrDefault(a => a.id == operationId_);
        if (string.IsNullOrWhiteSpace(newType))
        {
            throw new ArgumentException("Invalid operation type");
        }

        if (string.IsNullOrWhiteSpace(newDescription))
        {
            throw new ArgumentException("Invalid operation description");
        }
        if  (newAmount == 0 || newCategoryId == 0)
        {
            throw new ArgumentException("Invalid amount or categoryId");
        }
        
        operation.type = newType;
        operation.amount = newAmount;
        operation.date = newDate;
        operation.description = newDescription;
        operation.category_id = newCategoryId;
    }

    public void DeleteOperation(int operationId_)
    {
        var operation = operations.FirstOrDefault(a => a.id == operationId_);
        if (operation == null) throw new ArgumentException("Invalid operation type");
        operations.Remove(operation);
    }

    public Operation GetOperationById(int operationId)
    {
        var operation = operations.FirstOrDefault(a => a.id == operationId);
        if (operation == null) throw new ArgumentException("Invalid operation type");
        return operation;
    }

    public List<Operation> GetAllOperations()
    {
        return operations;
    }

    public List<Operation> GetOperationsByAccountId(int bankAccountId)
    {
        return operations.Where(a => a.bankAccountId == bankAccountId).ToList();
    }

    public List<Operation> GetOperationsByCategoryId(int categoryId)
    {
        return operations.Where(a => a.category_id == categoryId).ToList();
    }

    public List<Operation> GetOperationsByDateRange(DateTime startDate, DateTime endDate)
    {
        return operations
            .Where(o => o.date >= startDate && o.date <= endDate)
            .ToList();
    }
    
    public void ClearAllOperations()
    {
        operations.Clear();
    }
}