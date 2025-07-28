using ProductManagementAPI.Data;
using ProductManagementAPI.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ProductManagementAPI.Authorization;

namespace ProductManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]

    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ApplicationDbContext dbContext,
            ILogger<ProductsController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        [Authorize(Policy = "AgeGreaterThan25")]
       
        public ActionResult<IEnumerable<Product>> Get()
        {
            var userName = User.Identity.Name;
            var userId = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var records = _dbContext.Set<Product>().ToList();
            return Ok(records);
        }
        [HttpGet]
        [Route("{id}")]
        [LogSensitiveAction]
        public ActionResult GetById(int id)
        {
            _logger.LogDebug("Getting Product #" + id);
            var record = _dbContext.Set<Product>().Find(id);
            if (record == null)
                _logger.LogWarning("Product #{id} was not found -- time:{y}", id,DateTime.Now);
            return record == null ? NotFound() : Ok(record);
        }

        [HttpPost]
        [Route("")]
        public ActionResult<int> CreateProduct([FromBody]Product product, 
            [FromHeader(Name = "Accept-Language")]string languge)
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
