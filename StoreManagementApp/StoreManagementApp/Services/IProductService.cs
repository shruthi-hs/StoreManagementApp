using StoreManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagementApp.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetProductAsync(bool forceRefresh = false);

        Task<ProductModel> AddItemAsync(ProductModel product);

        Task<ProductModel> UpdateItemAsync(ProductModel product);

        Task<bool> DeleteItemAsync(int productId);
    }
}
