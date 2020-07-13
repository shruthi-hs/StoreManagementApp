using StoreManagementApp.Models;
using StoreManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoreManagementApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StockEditPage : ContentPage
    {
        StockEditViewModel viewModel;

        public StockEditPage(StockEditViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        public StockEditPage()
        {
            InitializeComponent();

            var item = new ProductModel();

            viewModel = new StockEditViewModel(item);
            BindingContext = viewModel;
        }

        async void UpdateStock_Clicked(object sender, EventArgs e)
        {
            var item = viewModel.product;
            MessagingCenter.Send(this, "UpdateStock", item.Stocks[0]);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

    }
}