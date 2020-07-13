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
    public class UserService : IUserService
    {
        HttpClient client;
        UserModel item;
        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public UserService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");

            item = new UserModel();
        }


        public async Task<UserModel> GetUserAsync(string username)
        {
            if (username == null || !IsConnected)
                return null;

            var json = await client.GetStringAsync("https://storemanagementsystem20200710122226.azurewebsites.net/api/user/getUserDetail/"+username);
            item = await Task.Run(() => JsonConvert.DeserializeObject<UserModel>(json));

            return item;
        }
    }
}

