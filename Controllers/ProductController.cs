using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationBackEnd.Data;
using WebApplicationBackEnd.Models;
using WebApplicationBackEnd.Models.Entities;

namespace WebApplicationBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
       private readonly ApplicationDbContext dbContext;

        public ProductController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllProduct() 
        {
            return Ok(dbContext.Products.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetProductById(Guid id)
        {
            var product = dbContext.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);    
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductDto addProductDto)
        {
            var productEntity = new Product()
            {
                id = Guid.NewGuid(),
                name = addProductDto.name,
                quantity = addProductDto.quantity,
                description = addProductDto.description,
                price = addProductDto.price,
                image = addProductDto.image,
                category = addProductDto.category,
            };

            dbContext.Products.Add(productEntity);
            dbContext.SaveChanges();

            return Ok(productEntity);  

        }

        [HttpPut]
        [Route("UpdateProduct/{id:guid}")]
        public IActionResult UpdateProduct(Guid id, UpdateProductDto updateProductDto)
        {
            var product = dbContext.Products.Find(id);

            if(product == null)
            {
                return NotFound();
            }

            product.name = updateProductDto.name;
            product.quantity = updateProductDto.quantity;
            product.description = updateProductDto.description;
            product.price = updateProductDto.price;

            dbContext.SaveChanges();

            return Ok(product);
        }

          [HttpPut]
        [Route("UpdateQuantity/{id:guid}")]
        public IActionResult UpdateProductQuantity(Guid id)
        {
            var product = dbContext.Products.Find(id);

            if(product == null)
            {
                return NotFound();
            }
            product.quantity = product.quantity - 1;
         
            dbContext.SaveChanges();

            return Ok(product);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var product = dbContext.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
            return Ok(product);
        }
    }
}
