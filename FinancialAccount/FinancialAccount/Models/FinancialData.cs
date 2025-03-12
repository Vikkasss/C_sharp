namespace FinancialAccounts.Models;

public class FinancialData
{
    public List<BankAccount> Accounts { get; set; }
    public List<Category> Categories { get; set; }
    public List<Operation> Operations { get; set; }
}