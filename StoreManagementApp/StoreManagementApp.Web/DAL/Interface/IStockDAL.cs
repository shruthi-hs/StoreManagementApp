
using StoreManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementApp.DAL.Interface
{
    public interface IStockDAL
    {
        Task<Stock> UpdateStock(Stock stock);
    }
}
