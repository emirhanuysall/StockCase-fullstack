using Backend.Models;
using System.Collections.Generic;

namespace Backend.Services
{
    public interface IStockService
    {
        List<Stock> GetAllStocks();
        Stock GetStockById(int id);
        void CreateStock(Stock stock);
        Stock UpdateStock(Stock stock);
        bool DeleteStock(int id);
    }
}


