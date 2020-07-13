using StoreManagementApp.BLL.Interface;
using StoreManagementApp.DAL.Interface;
using StoreManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementApp.BLL
{
    public class StockBLL:IStockBLL
    {
        private readonly IStockDAL _stockDAL;

        public StockBLL(IStockDAL stockDAL)
        {
            _stockDAL = stockDAL;
        }

        public async Task<Stock> UpdateStock(Stock stock)
        {
            return await _stockDAL.UpdateStock(stock);
        }
    }
}
