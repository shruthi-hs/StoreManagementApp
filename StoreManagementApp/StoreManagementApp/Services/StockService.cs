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
    public class StockService : IStockService
    {
        HttpClient client;
        IEnumerable<StockModel> items;
        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public StockService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");

            items = new List<StockModel>();
        }


        public async Task<StockModel> UpdateItemAsync(StockModel stock)
        {
            if (stock == null || !IsConnected)
                return null;

            var serializedItem = JsonConvert.SerializeObject(stock);

            var response = await client.PutAsync("https://storemanagementsystem20200710122226.azurewebsites.net/api/stocks/updateStock", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return stock;
        }
    }
}
