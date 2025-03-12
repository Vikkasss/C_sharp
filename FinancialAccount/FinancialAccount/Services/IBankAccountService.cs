using FinancialAccounts.Models;

namespace FinancialAccounts.Services;

public interface IBankAccountService
{
    BankAccount CreateAccount(string _name, decimal initialBalanse);
    BankAccount GetAccountById(int accountId);
    //void UpdateAccount(int accountId, decimal newBalance, string newName);
    void DeleteAccount(int accountId);
    void UpdateBalance(int accountId, decimal balance);
    void UpdateName(int accountId, string name);
    List<BankAccount> GetAllAccounts();

    void ClearAllAccounts();

}