using Newtonsoft.Json;
using StoreManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace StoreManagementApp.Services
{
    public class ProductService : IProductService
    {
        HttpClient client;
        IEnumerable<ProductModel> items;

        public ProductService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");

            items = new List<ProductModel>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public async Task<IEnumerable<ProductModel>> GetProductAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync("https://storemanagementsystem20200710122226.azurewebsites.net/api/products/getProducts");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<ProductModel>>(json));
            }

            return items;
        }

        public async Task<ProductModel> AddItemAsync(ProductModel item)
        {
            if (item == null || !IsConnected)
                return null;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync("https://storemanagementsystem20200710122226.azurewebsites.net/api/products/addProduct", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return item;
        }

        public async Task<ProductModel> UpdateItemAsync(ProductModel item)
        {
            if (item == null || !IsConnected)
                return null;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PutAsync("https://storemanagementsystem20200710122226.azurewebsites.net/api/products/editProduct", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return item;
        }

        public async Task<bool> DeleteItemAsync(int productId)
        {
            if (productId != 0 && !IsConnected)
                return false;

            var response = await client.DeleteAsync("https://storemanagementsystem20200710122226.azurewebsites.net/api/products/deleteProduct?productId=" + productId);

            return response.IsSuccessStatusCode;
        }
    }
}
