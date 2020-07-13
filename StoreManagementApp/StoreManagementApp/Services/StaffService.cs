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
    public class StaffService : IStaffService
    {
        HttpClient client;
        IEnumerable<StaffModel> items;

        public StaffService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");

            items = new List<StaffModel>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public async Task<IEnumerable<StaffModel>> GetStaffsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync("https://storemanagementsystem20200710122226.azurewebsites.net/api/staff/getStaff");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<StaffModel>>(json));
            }

            return items;
        }

        public async Task<StaffModel> AddItemAsync(StaffModel item)
        {
            if (item == null || !IsConnected)
                return null;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync("https://storemanagementsystem20200710122226.azurewebsites.net/api/staff/addStaff", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return item;
        }

        public async Task<StaffModel> UpdateItemAsync(StaffModel item)
        {
            if (item == null || !IsConnected)
                return null;

            var serializedItem = JsonConvert.SerializeObject(item);

            try
            {
                var response = await client.PutAsync("https://storemanagementsystem20200710122226.azurewebsites.net/api/staff/editStaff", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            }
            catch(Exception e)
            {

            }

            return item;
        }

        public async Task<bool> DeleteItemAsync(int staffId)
        {
            if (staffId!=0 && !IsConnected)
                return false;

            var response = await client.DeleteAsync("https://storemanagementsystem20200710122226.azurewebsites.net/api/staff/deleteStaff?staffId="+ staffId);

            return response.IsSuccessStatusCode;
        }
    }
}
