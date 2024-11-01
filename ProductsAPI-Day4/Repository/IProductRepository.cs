using ProductsAPI_Day4.Models;

namespace ProductsAPI_Day4.Repository
{
        public interface IProductRepository

        {

            IEnumerable<Product> GetProducts();

            Product GetProductByID(int product);

            void InsertProduct(Product product);

            void DeleteProduct(int productId);

            void UpdateProduct(Product product);

            void Save();

        }
}
