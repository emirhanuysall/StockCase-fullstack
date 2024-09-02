using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Services;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        public IActionResult GetAllStocks()
        {
            var stocks = _stockService.GetAllStocks();
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetStockById(int id)
        {
            var stock = _stockService.GetStockById(id);
            if (stock == null) return NotFound();
            return Ok(stock);
        }

        [HttpPost]
        public IActionResult CreateStock(Stock stock)
        {
            _stockService.CreateStock(stock);
            return CreatedAtAction(nameof(GetStockById), new { id = stock.Id }, stock);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStock(int id, Stock stock)
        {
            if (id != stock.Id) return BadRequest();
            var updatedStock = _stockService.UpdateStock(stock);
            if (updatedStock == null) return NotFound();
            return Ok(updatedStock);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStock(int id)
        {
            var success = _stockService.DeleteStock(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
