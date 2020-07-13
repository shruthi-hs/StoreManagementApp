using StoreManagementApp.Models;
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
    public partial class NewProductPage : ContentPage
    {
        public ProductModel product { get; set; }
        public decimal Quantity { get; set; }
        public NewProductPage()
        {
            InitializeComponent();
            product = new ProductModel();
            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            product.Stocks = new List<StockModel>();

            StockModel stock = new StockModel() { Quantity = Quantity };
            product.Stocks.Add(stock);

            product.CreatedDate = DateTime.Now;
            product.UpdatedDate = DateTime.Now;
            MessagingCenter.Send(this, "AddProduct", product);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}