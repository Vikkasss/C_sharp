using FinancialAccounts.Models;

namespace FinancialAccounts.Services;

public class BankAccountService : IBankAccountService
{
    private List<BankAccount> accounts;
    private int nextAccountId = 1; // Для генерации уникального ID

    public BankAccountService()
    {
        accounts = new List<BankAccount>();
    }
    public BankAccount CreateAccount(string _name, decimal initialBalanse)
    {
        if (string.IsNullOrEmpty(_name))
        {
            throw new ArgumentException("Name cannot be null or empty");
        }

        if (initialBalanse < 0)
        {
            throw new AggregateException("Balance cannot be negative.");
        }

        var newAccount = new BankAccount
        {
            id = nextAccountId++,
            name = _name,
            balance = initialBalanse
        };
        accounts.Add(newAccount);
        return newAccount;
    }
    
    public BankAccount GetAccountById(int accountId)
    {
        var account = accounts.FirstOrDefault(a => a.id == accountId);
        if (account == null)
        {
            throw new ArgumentException("There is no account with this id.");
        }
        return account;
    }
    
    public void UpdateBalance(int accountId, decimal newBalance)
    {
        var account = accounts.FirstOrDefault(a => a.id == accountId);
        if (account == null)
        {
            throw new ArgumentException("There is no account with this id.");
        }

        account.UpdateBalance(newBalance);
    }

    public void UpdateName(int accountId, string name)
    {
        var account = accounts.FirstOrDefault(a => a.id == accountId);
        if (account == null)
        {
            throw new ArgumentException("There is no account with this id.");
        }
        account.UpdateName(name);
    }
    
    // public void UpdateAccount(int accountId, decimal newBalance, string newName)
    // {
    //     var account = accounts.FirstOrDefault(a => a.id == accountId);
    //     if (account == null) throw new ArgumentException("There is no account with this id.");
    //     if (newBalance < 0) throw new AggregateException("Balance has not be negative.");
    //     if (string.IsNullOrEmpty(newName)) throw new ArgumentException("New name is empty.");
    //     
    //     // updating
    //     account.balance = newBalance;
    //     account.name = newName;
    // }

    public void DeleteAccount(int accountId)
    {
        var account = accounts.FirstOrDefault(a => a.id == accountId);
        if (account == null)
        {
            throw new ArgumentException("Счет с указанным ID не найден.");
        }
        accounts.Remove(account);
    }

    public List<BankAccount> GetAllAccounts()
    {
        return accounts;
    }

    public void ClearAllAccounts()
    {
        accounts.Clear();
    }
}