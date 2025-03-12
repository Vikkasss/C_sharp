using FinancialAccounts.Models;

namespace FinancialAccounts.Services;

public class CategoryService : ICategoryService
{
    private List<Category> categories;
    private int nextCategoryId = 1;

    public CategoryService()
    {
        categories = new List<Category>();
    }
    public Category CreateCategory(string type, string name)
    {
        if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException("String is null or empty!");
        }

        var newCategory = new Category()
        {
            type = type,
            id = nextCategoryId++,
            name = name
        };
        categories.Add(newCategory);
        return newCategory;
    }

    public void UpdateCategory(int categoryId, string type, string newName)
    {
        var category = categories.FirstOrDefault(x => x.id == categoryId);
        if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(newName))
        {
            throw new ArgumentNullException("String is null or empty!");
        }
        category.type = type;
        category.name = newName;
        
    }

    public void DeleteCategory(int categoryId)
    {
        var category = categories.FirstOrDefault(x => x.id == categoryId);
        if (category == null)
        {
            throw new ArgumentNullException("Category not found!");
        }
        categories.Remove(category);
    }

    public Category GetCategoryById(int categoryId)
    {
        var category = categories.FirstOrDefault(x => x.id == categoryId);
        if (category == null)
        {
            throw new ArgumentNullException("Category not found!");
        }
        return category;
    }

    public List<Category> GetAllCategories()
    {
        return categories;
    }
    
    public void ClearAllCategories()
    {
        categories.Clear();
    }
}