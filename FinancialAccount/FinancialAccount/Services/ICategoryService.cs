using FinancialAccounts.Models;

namespace FinancialAccounts.Services;

public interface ICategoryService
{
    Category CreateCategory(string type, string name);
    
    void UpdateCategory(int categoryId, string type, string newName);
    
    void DeleteCategory(int categoryId);
    
    Category GetCategoryById(int categoryId);
    
    List<Category> GetAllCategories();
    
    void ClearAllCategories();
    
}