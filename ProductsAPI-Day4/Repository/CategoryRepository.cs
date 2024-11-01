using Microsoft.EntityFrameworkCore;
using ProductsAPI_Day4.Data;
using ProductsAPI_Day4.Models;

namespace ProductsAPI_Day4.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductContext _dbContext;

        public CategoryRepository(ProductContext dbContext)

        {

            _dbContext = dbContext;

        }

        public void DeleteCategory(int categoryId)

        {

            var category = _dbContext.Categories.Find(categoryId);

            _dbContext.Categories.Remove(category);

            Save();

        }

        public Category GetCategoryByID(int categoryId)

        {

            return _dbContext.Categories.Find(categoryId);

        }

        public IEnumerable<Category> GetCategories()

        {

            return _dbContext.Categories.ToList();

        }

        public void InsertCategory(Category category)

        {

            _dbContext.Add(category);

            Save();
        }

        public void Save()

        {

            _dbContext.SaveChanges();

        }

        public void UpdateCategory(Category category)

        {

            _dbContext.Entry(category).State = EntityState.Modified;

            Save();

        }
    }
}
