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
    public partial class ProductDetailPage : ContentPage
    {
        ProductDetailViewModel viewModel;

        public ProductDetailPage(ProductDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        public ProductDetailPage()
        {
            InitializeComponent();

            var item = new ProductModel();          

            viewModel = new ProductDetailViewModel(item);
            BindingContext = viewModel;
        }

        async void UpdateProduct_Clicked(object sender, EventArgs e)
        {
            var item = viewModel.product;
            item.CreatedDate = DateTime.Now;
            item.UpdatedDate = DateTime.Now;
            MessagingCenter.Send(this, "UpdateProduct", item);
            await Navigation.PopModalAsync();
        }

        async void DeleteProduct_Clicked(object sender, EventArgs e)
        {
            var item = viewModel.product;
            MessagingCenter.Send(this, "DeleteProduct", item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}