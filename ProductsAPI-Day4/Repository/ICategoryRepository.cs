using ProductsAPI_Day4.Models;

namespace ProductsAPI_Day4.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();

        Category GetCategoryByID(int category);

        void InsertCategory(Category category);

        void DeleteCategory(int categoryId);

        void UpdateCategory(Category category);

        void Save();
    }
}
