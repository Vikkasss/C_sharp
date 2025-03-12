# Описание проекта FinancialAccount
Проект **FinancialAccount** представляет собой систему управления финансовыми данными, включая счета, категории и операции. В проекте используются различные паттерны проектирования для обеспечения гибкости и удобства поддержки кода.

### Структура проекта
- `Models/`
    - BankAccount.cs — модель банковского счета
    - Category.cs — модель категории операций
    - Operation.cs — модель финансовой операции
    - FinancialData.cs — контейнер для всех данных (счета, категории, операции)
- `Patterns/`
    - `Command/`
    - `Decorator/`
    - `ExportStrategies/`
    - `Facade/`
    - `Factory/`
    - `ImportStrategies/`
    - `Observer/`
- `Services/`
    - AnalyticsService.cs — сервис для аналитики операций
    - BankAccountService.cs — сервис для управления счетами
    - CategoryService.cs — сервис для управления категориями
    - DataImportExportService.cs — сервис для импорта/экспорта данных
    - IAnalyticsService.cs — интерфейс реализации аналитики операции
    - IBankAccountService.cs — интерфейс реализации управления счетами
    - ICategoryService.cs — интерфейс реализации управления категориями
    - IDataImportExportService.cs — интерфейс реализации импорта/экспорта данных
    - IOperationService.cs — интерфейс реализации управления операциями
    - OperationService.cs — сервис для управления операциями
- `Testing/`
    - `FinancialExports`
    - DataImportTester.cs — тестирование импорта/экспорта данных и паттернов
- Program.cs

### Подробнее о паттернах

| Паттерн | Описание | Применение |
|----:|:----:|:----------|
|Command|Паттерн Command инкапсулирует запросы как объекты, позволяя параметризовать клиентов с различными запросами, ставить запросы в очередь или поддерживать отмену операций.|```var command = new CreateOperationCommand(operationService, operation);
command.Execute(); // Создает операцию
command.Undo();    // Отменяет операцию|```
|Facade|||
