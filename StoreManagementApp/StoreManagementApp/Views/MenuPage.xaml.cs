using StoreManagementApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoreManagementApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();


            if (((App)Application.Current).IsManager)
            {
                menuItems = new List<HomeMenuItem>
                {
                    new HomeMenuItem {Id = MenuItemType.Staff, Title="Staff Management" },
                    new HomeMenuItem {Id = MenuItemType.Product, Title="Product Management" }
                };
            }
            else
            {
                menuItems = new List<HomeMenuItem>
                {
                    new HomeMenuItem {Id = MenuItemType.Stock, Title="Stock Management" }
                };
            }
               

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }

        async void LogOut_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
        }
    }
}