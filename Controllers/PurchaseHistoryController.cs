using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationBackEnd.Data;
using WebApplicationBackEnd.Models;
using WebApplicationBackEnd.Models.Entities;

namespace WebApplicationBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseHistoryController : ControllerBase
    {
             private readonly ApplicationDbContext dbContext;

        public PurchaseHistoryController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllPurchaseHistory() 
        {
            return Ok(dbContext.PurchaseHistories.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetPurchaseHistoryById(Guid id)
        {
            var purchasehistory = dbContext.PurchaseHistories.Find(id);

            if (purchasehistory == null)
            {
                return NotFound();
            }

            return Ok(purchasehistory);    
        }

        [HttpPost]
        public IActionResult AddPurchaseHistory(AddPurchaseHistoryDto addPurchaseHistoryDto)
        {
            var purchasehistorEntity = new PurchaseHistory()
            {
                ProductId = addPurchaseHistoryDto.ProductId,
                UserId = addPurchaseHistoryDto.UserId,
                PurchaseDate = addPurchaseHistoryDto.PurchaseDate,
                Quantity = addPurchaseHistoryDto.Quantity,
                UserName = addPurchaseHistoryDto.UserName,
                ProductName = addPurchaseHistoryDto.ProductName
            };

            dbContext.PurchaseHistories.Add(purchasehistorEntity);
            dbContext.SaveChanges();

            return Ok(purchasehistorEntity);  

        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdatePurchaseHistory(Guid id, UpdatePurchaseHistoryDto updatePurchaseHistoryto)
        {
            var purchasehistory = dbContext.PurchaseHistories.Find(id);

            if(purchasehistory == null)
            {
                return NotFound();
            }

            purchasehistory.ProductId = updatePurchaseHistoryto.ProductId;
            purchasehistory.UserId = updatePurchaseHistoryto.UserId;
            purchasehistory.PurchaseDate = updatePurchaseHistoryto.PurchaseDate;
            purchasehistory.Quantity = updatePurchaseHistoryto.Quantity;
            purchasehistory.UserName = updatePurchaseHistoryto.UserName;
            purchasehistory.ProductName = updatePurchaseHistoryto.ProductName;

            dbContext.SaveChanges();

            return Ok(purchasehistory);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeletePurchaseHistory(Guid id)
        {
            var purchasehistory = dbContext.PurchaseHistories.Find(id);

            if (purchasehistory == null)
            {
                return NotFound();
            }

            dbContext.PurchaseHistories.Remove(purchasehistory);
            dbContext.SaveChanges();
            return Ok(purchasehistory);
        }
    }
}
