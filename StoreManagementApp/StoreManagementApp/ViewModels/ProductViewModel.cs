using StoreManagementApp.Models;
using StoreManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StoreManagementApp.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public ObservableCollection<ProductModel> Product { get; set; }
        public Command LoadItemsCommand { get; set; }

        public Command ProductClicked { get; set; }

        public ProductViewModel()
        {
            Title = "Product Management";
            Product = new ObservableCollection<ProductModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewProductPage, ProductModel>(this, "AddProduct", async (obj, item) =>
            {
                var newItem = item as ProductModel;
                Product.Add(newItem);
                await ProductService.AddItemAsync(newItem);
            });


            MessagingCenter.Subscribe<ProductDetailPage, ProductModel>(this, "UpdateProduct", async (obj, item) =>
            {
                var updatedItem = item as ProductModel;
                await ProductService.UpdateItemAsync(updatedItem);
            });

            MessagingCenter.Subscribe<ProductDetailPage, ProductModel>(this, "DeleteProduct", async (obj, item) =>
            {
                var deleteItem = item as ProductModel;
                await ProductService.DeleteItemAsync(deleteItem.ProductId);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Product.Clear();
                var items = await ProductService.GetProductAsync(true);
                foreach (var item in items)
                {
                    if(item.IsActive)
                        Product.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }


    }
}
