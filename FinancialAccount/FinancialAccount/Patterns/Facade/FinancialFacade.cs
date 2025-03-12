using FinancialAccounts.Models;
using FinancialAccounts.Services;

namespace FinancialAccount.Patterns.Command;

public class FinancialFacade
{
    private readonly IBankAccountService bankAccountService;
    private readonly ICategoryService categoryService;

    public FinancialFacade(IBankAccountService _bankAccountService, ICategoryService _categoryService)
    {
        bankAccountService = _bankAccountService;
        categoryService = _categoryService;
    }

    public void CreateAccountWithCategory(string accountName, decimal balance, string categoryName)
    {
        var account = bankAccountService.CreateAccount(accountName, balance);
        var category = categoryService.CreateCategory("Expense", categoryName);
        Console.WriteLine($"Счет {accountName} и категория {categoryName} созданы!");
    }
}