using System.Globalization;
using CsvHelper.Configuration;
using FinancialAccount.Patterns.Decorator;
using FinancialAccount.Patterns.Factory;
using FinancialAccount.Patterns.ImportStrategies;
using FinancialAccount.Patterns.Strategy;
using FinancialAccounts.Models;

namespace FinancialAccounts.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using YamlDotNet.Serialization;

public class DataImportExportService : IDataImportExportService
{
    private readonly IBankAccountService bankAccountService;
    private readonly ICategoryService categoryService;
    private readonly IOperationService operationService;
    private readonly IStrategyFactory strategyFactory;
    public DataImportExportService(IBankAccountService _bankAccountService,ICategoryService _categoryService, 
        IOperationService _operationService, IStrategyFactory _strategyFactory)
    {
        bankAccountService = _bankAccountService;
        categoryService = _categoryService;
        operationService = _operationService;
        strategyFactory = _strategyFactory;
    }
    
    public void ExportDataToFile(string filePath, FinancialData data)
    {
        var format = Path.GetExtension(filePath).Trim('.');
        var strategy = strategyFactory.CreateExportStrategy(format);
        strategy.Export(filePath, data);
    }
    public void ExportDataToFile(string filePath, string format)
    {
        var data = GetFinancialData();
        var strategy = strategyFactory.CreateExportStrategy(format);
        strategy.Export(filePath, data);
    }

    public void ImportDataFromFile(string filePath, string format)
    {
        var data = strategyFactory.CreateImportStrategy(format).Import(filePath);
        UpdateServices(data);
    }
    
    public FinancialData ImportData(string sourcePath, string format)
    {
        var strategy = strategyFactory.CreateImportStrategy(format);
        var data = strategy.Import(sourcePath);
        UpdateServices(data);
        return data;
    }

    private FinancialData GetFinancialData() => new()
    {
        Accounts = bankAccountService.GetAllAccounts(),
        Categories = categoryService.GetAllCategories(),
        Operations = operationService.GetAllOperations()
    };
    
    private void UpdateServices(FinancialData data)
    {
        // Очищаем существующие данные
        bankAccountService.ClearAllAccounts();
        categoryService.ClearAllCategories();
        operationService.ClearAllOperations();

        // Добавляем новые данные
        data.Accounts.ForEach(a => bankAccountService.CreateAccount(a.name, a.balance));
        data.Categories.ForEach(c => categoryService.CreateCategory(c.type, c.name));
        data.Operations.ForEach(o => operationService.CreateOperation(
            o.type, o.bankAccountId, o.amount, o.date, o.description, o.category_id));
    }
}