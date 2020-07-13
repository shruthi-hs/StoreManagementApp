using StoreManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagementApp.Services
{
    public interface IStockService
    {
        Task<StockModel> UpdateItemAsync(StockModel stock);
    }
}
