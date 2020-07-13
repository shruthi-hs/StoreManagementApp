using Microsoft.EntityFrameworkCore;
using StoreManagementApp.DAL.Interface;
using StoreManagementApp.Model;
using StoreManagementApp.Web.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementApp.DAL
{
    public class ProductDAL: IProductDAL
    {

        private readonly InventoryDBContext _inventoryDBContext;

        public ProductDAL(InventoryDBContext inventoryDBContext)
        {
            _inventoryDBContext = inventoryDBContext;
        }

        public async Task<Product> AddProduct(Product product)
        {
            try
            {
                if (product != null)
                {
                    product.IsActive = true;
                    product.CreatedDate = DateTime.Now;
                    await _inventoryDBContext.Products.AddRangeAsync(product);
                    await _inventoryDBContext.SaveChangesAsync();
                    return product;
                }
                return product;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            var deleteProduct = await _inventoryDBContext.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();

            if (deleteProduct != null)
            {
                deleteProduct.IsActive = false;
                await _inventoryDBContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Product> EditProduct(Product product)
        {
            Product existingProduct = await _inventoryDBContext.Products.Where(temp => temp.ProductId == product.ProductId).FirstOrDefaultAsync();

            if (existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.Description = product.Description;
                existingProduct.SKU = product.SKU;
                existingProduct.Price = product.Price;
                existingProduct.IsActive = product.IsActive;
                existingProduct.UpdatedDate = DateTime.Now;
                _inventoryDBContext.SaveChanges();

                return existingProduct;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _inventoryDBContext.Products.Include(p=>p.Stocks).ToListAsync();
        }

    }
}
