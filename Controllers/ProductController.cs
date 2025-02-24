using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationBackEnd.Data;

namespace WebApplicationBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ProductController(ApplicationDbContext context)
        {
            this.context = context;
        }

 

        [HttpGet]
        public IActionResult GetAll()
        {
            var allproduct = context.Products.ToList();
            return Ok(allproduct);
        }
    }
}
