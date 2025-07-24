using AspNetCoreForBeginners.Data;
using AspNetCoreForBeginners.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreForBeginners.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ApllicationDbContext _dbContext;

        public ProductsController(ApllicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("")]

        public ActionResult<IEnumerable<Product>> Get()
        {
            var records = _dbContext.Set<Product>().ToList();
            return Ok(records);
        }
        [HttpGet]
        [Route("{id}")]
        [LogSensitiveAction]
        public ActionResult GetById(int id)
        {
            var record = _dbContext.Set<Product>().Find(id);
            return record == null ? NotFound() : Ok(record);
        }

        [HttpPost]
        [Route("")]
        public ActionResult<int> CreateProduct(Product product)
        {
            product.Id = 0;
            _dbContext.Set<Product>().Add(product);
            _dbContext.SaveChanges();
            return Ok(product.Id);
        }

        [HttpPut]
        [Route("")]
        public ActionResult UpdateProdect(Product product)
        {
            var existingProduct = _dbContext.Set<Product>().Find(product.Id);
            existingProduct.Name = product.Name;
            existingProduct.Sku = product.Sku;
            _dbContext.Set<Product>().Update(existingProduct);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteProdect(int id)
        {
            var existingProduct = _dbContext.Set<Product>().Find(id);
            _dbContext.Set<Product>().Remove(existingProduct);
            _dbContext.SaveChanges();
            return Ok();
        }



    }
}
