using Microsoft.AspNetCore.Mvc;
using ProductsAPI_Day4.Models;
using ProductsAPI_Day4.Repository;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsAPI_Day4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)

        {

            _categoryRepository = categoryRepository;

        }

        // GET: api/Product

        [HttpGet]

        public IActionResult Get()

        {

            var categories = _categoryRepository.GetCategories();

            return new OkObjectResult(categories);

        }

        // GET: api/Product/5

        [HttpGet("{id}", Name = "Get")]

        public IActionResult Get(int id)

        {

            var category = _categoryRepository.GetCategoryByID(id);

            return new OkObjectResult(category);

        }

        // POST: api/Product

        [HttpPost]

        public IActionResult Post([FromBody] Category category)

        {

            using (var scope = new TransactionScope())

            {

                _categoryRepository.InsertCategory(category);

                scope.Complete();

                return CreatedAtAction(nameof(Get), new { id = category.Id }, category);

            }

        }

        // PUT: api/Product/5

        [HttpPut]

        public IActionResult Put([FromBody] Category category)

        {

            if (category != null)

            {

                using (var scope = new TransactionScope())

                {

                    _categoryRepository.UpdateCategory(category);

                    scope.Complete();

                    return new OkResult();

                }

            }

            return new NoContentResult();

        }

        // DELETE: api/ApiWithActions/5

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)

        {

            _categoryRepository.DeleteCategory(id);

            return new OkResult();

        }
    }
}
