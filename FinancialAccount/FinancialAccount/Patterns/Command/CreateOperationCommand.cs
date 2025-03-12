using FinancialAccounts.Models;
using FinancialAccounts.Services;

namespace FinancialAccount.Patterns.Command;

public class CreateOperationCommand : ICommand
{
    private readonly IOperationService _operationService;
    private Operation _operation;
    private int _createdOperationId; 
    
    public CreateOperationCommand(IOperationService operationService, Operation operation)
    {
        _operationService = operationService;
        _operation = operation;
    }
    
    public void Execute()
    {
        var createdOp = _operationService.CreateOperation(
            _operation.type, 
            _operation.bankAccountId, 
            _operation.amount, 
            _operation.date, 
            _operation.description, 
            _operation.category_id
        );
        _createdOperationId = createdOp.id;
    }
    
    public void Undo()
    {
        if (_createdOperationId != -1)
        {
            _operationService.DeleteOperation(_createdOperationId);
        } else
        {
            throw new InvalidOperationException("Cannot undo: operation was not executed.");
        }
    }
    
}