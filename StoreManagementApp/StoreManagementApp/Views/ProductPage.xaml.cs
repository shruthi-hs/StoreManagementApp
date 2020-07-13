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
    public partial class ProductPage : ContentPage
    {
        ProductViewModel viewModel;
        public ProductPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ProductViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Product.Count == 0)
                viewModel.IsBusy = true;
        }

        async void View_Clicked(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var item = (ProductModel)layout.BindingContext;
            await Navigation.PushModalAsync(new NavigationPage(new ProductDetailPage(new ProductDetailViewModel(item))));
        }


        async void AddProduct_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewProductPage()));
        }
    }
}