namespace FinancialAccounts.Services;

public interface IDataImportExportService
{
    void ExportDataToFile(string filePath, string format);   // format: CSV, JSON, YAML
    void ImportDataFromFile(string filePath, string format); // format: CSV, JSON, YAML
}