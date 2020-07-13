using StoreManagementApp.BLL.Interface;
using StoreManagementApp.DAL.Interface;
using StoreManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace StoreManagementApp.BLL
{
    public class ProductBLL : IProductBLL
    {
        private readonly IProductDAL _productDAL;

        public ProductBLL(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }
        public async Task<List<Product>> GetProducts()
        {
            return await _productDAL.GetProducts();
        }

        public async Task<Product> AddProduct(Product newProduct)
        {
            Product asset;

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    asset = await _productDAL.AddProduct(newProduct);
                    scope.Complete();

                }
                catch (Exception)
                {
                    asset = null;
                    throw;
                }
            }
            return asset;
        }


        public async Task<bool> DeleteProduct(int productId)
        {
            bool status = false;

            if (productId > 0)
                status = await _productDAL.DeleteProduct(productId);

            return status;
        }

        public async Task<Product> EditProduct(Product product)
        {
            return await _productDAL.EditProduct(product);
        }



    }
}
