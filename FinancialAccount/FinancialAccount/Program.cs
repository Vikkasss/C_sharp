
using FinancialAccount.Patterns.Command;
using FinancialAccount.Patterns.Decorator;
using FinancialAccount.Patterns.Factory;
using FinancialAccount.Patterns.Observer;
using FinancialAccount.Patterns.Strategy;
using FinancialAccount.Testing;
using FinancialAccounts.Models;
using FinancialAccounts.Services;

namespace FinancialAccount
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Настройка сервисов
            var bankAccountService = new BankAccountService();
            var categoryService = new CategoryService();
            var operationService = new LoggingOperationService(new OperationService()); // Decorator
            var strategyFactory = new StrategyFactory();
        
            var service = new DataImportExportService(
                bankAccountService,
                categoryService,
                operationService,
                strategyFactory);
            
            CreateTestData(bankAccountService, categoryService, operationService);
            
            ExportTestData(service);
            
            new DataImportTester("../../../Testing/FinancialExports").RunAllTests();
            
            Console.WriteLine("Для удобства результаты продублированы в файл, который находится в папке для тестирования");
        }
        private static void CreateTestData(
            IBankAccountService bankAccountService,
            ICategoryService categoryService,
            IOperationService operationService)
        {
            // Использование фасада
            var facade = new FinancialFacade(bankAccountService, categoryService);
            facade.CreateAccountWithCategory("Facade Account", 5000, "Special Category");

            // Создаем дополнительные данные
            var account = bankAccountService.CreateAccount("Main Account", 1000);
            var category = categoryService.CreateCategory("Expense", "Cafe");
            operationService.CreateOperation("Expense", account.id, 500, DateTime.Now, "Lunch", category.id);
        }

        private static void ExportTestData(DataImportExportService service)
        {
            const string exportPath = "../../../Testing/FinancialExports";
            Directory.CreateDirectory(exportPath);

            // Экспортируем данные
            service.ExportDataToFile(Path.Combine(exportPath, "data.json"), "json");
            service.ExportDataToFile(Path.Combine(exportPath, "data.yaml"), "yaml");
            service.ExportDataToFile(exportPath, "csv");
        }
    }
}
    
