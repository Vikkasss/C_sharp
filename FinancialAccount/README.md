# Описание проекта FinancialAccount
Проект **FinancialAccount** представляет собой систему управления финансовыми данными, включая счета, категории и операции. В проекте используются различные паттерны проектирования для обеспечения гибкости и удобства поддержки кода.

### Структура проекта
- `Models/`
    - _BankAccount.cs_ содержит модель банковского счета и реализует паттерн Observer для уведомления об изменениях
    - _Category.cs_ содержит модель категории операций
    - _Operation.cs_ — содержит модель финансовой операции
    - _FinancialData.cs_ — контейнер для хранения всех данных: счетов, категорий и операций
- `Patterns/`
    - `Command/`
    - `Decorator/`
    - `ExportStrategies/`
    - `Facade/`
    - `Factory/`
    - `ImportStrategies/`
    - `Observer/`
- `Services/`
    - _AnalyticsService.cs_ — сервис для аналитики операций: расчет разницы баланса, группировка по категориям
    - _BankAccountService.cs_ — сервис для управления счетами: создание, обновление, удаление
    - _CategoryService.cs_ — сервис для управления категориями: создание, обновление, удаление
    - _DataImportExportService.cs_ — сервис для импорта и экспорта данных в различных форматах (JSON, YAML, CSV)
    - _IAnalyticsService.cs_ — интерфейс реализации аналитики операции
    - _IBankAccountService.cs_ — интерфейс реализации управления счетами
    - _ICategoryService.cs_ — интерфейс реализации управления категориями
    - _IDataImportExportService.cs_ — интерфейс реализации импорта/экспорта данных
    - _IOperationService.cs_ — интерфейс реализации управления операциями
    - _OperationService.cs_ — сервис для управления операциями: создание, обновление, удаление
- `Testing/`
    - `FinancialExports`
    - _DataImportTester.cs_ — тестирует импорт и экспорт данных, используя паттерны, проверяет целостность данных
- Program.cs

### Подробнее о паттернах

| Паттерн | Описание | Название папки в структуре|
|----|----|----|
| **Command** | Паттерн Command инкапсулирует запросы как объекты, позволяя параметризовать клиентов с различными запросами, ставить запросы в очередь или поддерживать отмену операций. |`Command/`|

**Применение**
```
var command = new CreateOperationCommand(operationService, operation);
command.Execute(); // Создает операцию
command.Undo();    // Отменяет операцию
```

| Паттерн | Описание | Название папки в структуре|
|----|----|----|
| **Decorator** | Паттерн Decorator позволяет динамически добавлять поведение объектам, не изменяя их исходный код.Добавляет логирование при создании, обновлении и удалении операций. |`Decorator/`|

**Применение**
```
var operationService = new LoggingOperationService(new OperationService());
operationService.CreateOperation("Expense", 1, 500, DateTime.Now, "Lunch", 1);
// Вывод: Create operation: Expense, 1, 500, 12.03.2024 14:00:00, Lunch
```

| Паттерн | Описание | Название папки в структуре|
|----|----|----|
| **Facade** | Паттерн Facade предоставляет простой интерфейс для работы со сложной подсистемой. Упрощает создание счета и категории в одной операции. |`Facade/`|

**Применение**

```
var facade = new FinancialFacade(bankAccountService, categoryService);
facade.CreateAccountWithCategory("Main Account", 1000, "Food");
```

| Паттерн | Описание | Название папки в структуре|
|----|----|----|
| **Factory** | Паттерн Factory создает объекты, не указывая их конкретных классов. Создает стратегии экспорта и импорта данных (JSON, YAML, CSV). |`Factory/`|

**Применение**
```
var factory = new StrategyFactory();
var exportStrategy = factory.CreateExportStrategy("json");
exportStrategy.Export("data.json", financialData);
```

| Паттерн | Описание | Название папки в структуре|
|----|----|----|
| **Observer** | Паттерн Observer позволяет объектам подписываться на изменения других объектов и реагировать на них. Используется в `BankAccount.cs`, при изменении баланса или имени счета уведомляются наблюдатели. |`Observer/`|

**Применение**
```
var account = new BankAccount();
var observer = new ConsoleObserver();
account.AddObserver(observer);
account.UpdateBalance(1500); // Вывод: [OBSERVER] Balance account id: 1 changes: 1500
```

| Паттерн | Описание | Название папки в структуре|
|----|----|----|
| **Strategy** | Паттерн Strategy позволяет выбирать алгоритм выполнения операции во время выполнения программы. Паттерн реализует различные стратегии экспорта (JSON, YAML, CSV) и импорта данных.|`ImportStrategies/` и `ExportStrategies/` |

**Применение**
```
var exportStrategy = new JsonExportStrategy();
exportStrategy.Export("data.json", financialData);
```
### Работа программы: 
1. В файле `program.cs` создаются сервисы для работы с данными (`BankAccountService`, `CategoryService`, `OperationService`)
2. Используя фасад `FinancialFacade`, создаются счета и категории. Затем добавляются операции _(реализация через этот паттерн реализована в файле `DataImportTester.cs`)_
3. Происходит экспорт данных в три формата: JSON, YAML и CSV.
4. Запускаются тесты для проверки корректности импорта данных из всех форматов.
5. После импорта проверяется, что данные были корректно восстановлены.
