using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using StoreManagementApp.Models;

namespace StoreManagementApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
                
            InitializeComponent();

            if (((App)Application.Current).IsManager)
            {
                Detail = new NavigationPage(new Staff());
            }
            else
            {
                Detail = new NavigationPage(new StockPage());
            }

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Staff, (NavigationPage)Detail);

        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {                    
                    case (int)MenuItemType.Staff:
                        {
                            MenuPages.Add(id, new NavigationPage(new Staff()));
                            break;
                        }

                    case (int)MenuItemType.Product:
                        MenuPages.Add(id, new NavigationPage(new ProductPage()));
                        break;

                    case (int)MenuItemType.Stock:
                        MenuPages.Add(id, new NavigationPage(new StockPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}