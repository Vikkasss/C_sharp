using System;
using System.IO;
using FinancialAccount.Patterns.Command;
using FinancialAccount.Patterns.Decorator;
using FinancialAccount.Patterns.Factory;
using FinancialAccount.Patterns.Observer;
using FinancialAccounts.Models;
using FinancialAccounts.Services;

namespace FinancialAccount.Testing;
public class DataImportTester
{
    private readonly DataImportExportService _dataImportExportService;
    private readonly string _testDirectory;
    private readonly StreamWriter _logWriter;
    private readonly IOperationService _operationService;

    public DataImportTester(string testDirectory)
    {
        _testDirectory = testDirectory;
        Directory.CreateDirectory(_testDirectory);
        _logWriter = new StreamWriter(Path.Combine(_testDirectory, "test_results.txt"));
        
        // Создаем новые сервисы для импорта, чтобы не смешивать с оригинальными данными
        var bankService = new BankAccountService();
        var categoryService = new CategoryService();
        var operationService = new LoggingOperationService(new OperationService()); // using decorator
        var strategyFactory = new StrategyFactory(); 
        
        _operationService = operationService;

        
        // observer test 
        var account = bankService.CreateAccount("Test", 1000);
        var observer = new ConsoleObserver();
        account.AddObserver(observer);
        account.UpdateBalance(1500);
            
        _dataImportExportService = new DataImportExportService(
            bankService, 
            categoryService, 
            operationService, strategyFactory);
    }

    public void RunAllTests()
    {
        TestPatterns();
        TestExportImport();
        _logWriter.Close();
    }

    private void TestPatterns()
    {
        WriteHeader("TESTING PATTERNS");
        TestCommandPattern();
        TestFacadePattern();
    }

    private void TestCommandPattern()
    {
        WriteTestHeader("COMMAND PATTERN");
        var operation = new Operation
        {
            type = "Expense",
            amount = 1000,
            bankAccountId = 1,
            category_id = 1,
            date = DateTime.Now,
            description = "Test command pattern",
        };

        var command = new CreateOperationCommand(_operationService, operation);
        try 
        {
            command.Execute();
            WriteSuccess("Operation created successfully!");
        }
        catch (Exception ex)
        {
            WriteError($"Execute failed: {ex.Message}");
            return;
        }
    
        try 
        {
            command.Undo();
            WriteSuccess("Operation undo successfully!");
        }
        catch (Exception ex)
        {
            WriteError($"Undo failed: {ex.Message}");
        }
    }

    private void TestFacadePattern()
    {
        WriteTestHeader("FACADE PATTERN");
        var facade = new FinancialFacade(
            new BankAccountService(),
            new CategoryService());
        
        facade.CreateAccountWithCategory("Facade Account", 200, "Facade category");
    }

    private void TestExportImport()
    {
        WriteHeader("EXPORT/IMPORT TESTING");
        foreach (var format in new[] { "json", "yaml", "csv" })
        {
            TestImport(format);
        }
    }
    
    public void TestImport(string format)
    {
        try
        {
            WriteTestHeader($"{format.ToUpper()} IMPORT TEST");
            string sourcePath = format.ToLower() == "csv" 
                ? _testDirectory // Для CSV используем папку
                : Path.Combine(_testDirectory, $"data.{format}"); // Для JSON/YAML используем файл
                
            var importedData = new DataImportExportService(
                new BankAccountService(),
                new CategoryService(),
                new OperationService(),
                new StrategyFactory()).ImportData(sourcePath, format);
            PrintValidationResults(importedData);
            WriteSuccess($"\n{format.ToUpper()} import test completed successfully!");
        }
        catch (Exception ex)
        {
            WriteError($"Import test failed: {ex.Message}");
        }
    }

    private void PrintValidationResults(FinancialData data)
    {
        WriteInfo("\nValidation Results:");
            
        PrintCollectionStatus("Accounts", data.Accounts?.Count);
        PrintCollectionStatus("Categories", data.Categories?.Count);
        PrintCollectionStatus("Operations", data.Operations?.Count);

        if (data.Accounts?.Count > 0)
        {
            Console.WriteLine("\nSample Account:");
            Console.WriteLine($"ID: {data.Accounts[0].id}");
            Console.WriteLine($"Name: {data.Accounts[0].name}");
            Console.WriteLine($"Balance: {data.Accounts[0].balance:C}");
        }
    }
    private void PrintCollectionStatus(string name, int? count)
    {
        var message = $"{name}: {(count?.ToString() ?? "NULL")} records";
        if (count.HasValue && count > 0)
            WriteSuccess(message);
        else
            WriteError(message);
    }
    
    #region Helpers

    private void WriteHeader(string text)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\n{new string('=', 40)}");
        Console.WriteLine(text);
        Console.WriteLine(new string('=', 40));
        Console.ResetColor();
        
        _logWriter.WriteLine($"\n==== {text} ====\n");
    }

    private void WriteSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
        _logWriter.WriteLine($"[SUCCESS] {message}");
    }

    private void WriteError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
        _logWriter.WriteLine($"[ERROR] {message}");
    }

    private void WriteInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(message);
        Console.ResetColor();
        _logWriter.WriteLine($"[INFO] {message}");
    }
    private void WriteTestHeader(string text)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n{text}");
        Console.ResetColor();
        
        _logWriter.WriteLine($"\n{text}");
    }
    #endregion
}
