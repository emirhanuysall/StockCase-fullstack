using System.Collections.Generic;
using System.Linq;
using Backend.Models;
using Backend.Data;

namespace Backend.Services
{
    public class StockService : IStockService
    {
        private readonly DataContext _context;

        public StockService(DataContext context)
        {
            _context = context;
        }

        public List<Stock> GetAllStocks()
        {
            return _context.Stocks.ToList();
        }

        public Stock GetStockById(int id)
        {
            return _context.Stocks.Find(id);
        }

        public void CreateStock(Stock stock)
        {
            _context.Stocks.Add(stock);
            _context.SaveChanges();
        }

        public Stock UpdateStock(Stock stock)
        {
            var existingStock = _context.Stocks.Find(stock.Id);
            if (existingStock == null) return null;

            existingStock.Name = stock.Name;
            existingStock.Description = stock.Description;
            existingStock.Quantity = stock.Quantity;
            existingStock.UnitPrice = stock.UnitPrice;
            _context.SaveChanges();

            return existingStock;
        }

        public bool DeleteStock(int id)
        {
            var stock = _context.Stocks.Find(id);
            if (stock == null) return false;

            _context.Stocks.Remove(stock);
            _context.SaveChanges();

            return true;
        }
    }
}

