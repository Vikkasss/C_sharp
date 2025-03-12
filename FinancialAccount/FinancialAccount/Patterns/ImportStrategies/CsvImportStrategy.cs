using System.Globalization;
using CsvHelper.Configuration;
using FinancialAccounts.Models;

namespace FinancialAccount.Patterns.ImportStrategies;

public class CsvImportStrategy : IImportStrategy
{
    public FinancialData Import(string filePath)
    {
        return new FinancialData
        {
            Accounts = ReadCsv<BankAccount>(Path.Combine(filePath, "accounts.csv")),
            Categories = ReadCsv<Category>(Path.Combine(filePath, "categories.csv")),
            Operations = ReadCsv<Operation>(Path.Combine(filePath, "operations.csv"))
        };
    }
    
    private List<T> ReadCsv<T>(string filePath)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";", // Указываем правильный разделитель
            HeaderValidated = null, // Игнорируем проверку заголовков
            MissingFieldFound = null
        };
        using var reader = new StreamReader(filePath);
        using var csv = new CsvHelper.CsvReader(reader, config);
        return csv.GetRecords<T>().ToList();
    }
}