
using StoreManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementApp.BLL.Interface
{
    public interface IStockBLL
    {
        Task<Stock> UpdateStock(Stock stock);
    }
}
