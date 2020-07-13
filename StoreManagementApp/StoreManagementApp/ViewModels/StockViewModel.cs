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
    public class StockViewModel : BaseViewModel
    {
        public ObservableCollection<ProductModel> Product { get; set; }
        public Command LoadItemsCommand { get; set; }

        public Command StockClicked { get; set; }

        public StockViewModel()
        {
            Title = "Stock Management";
            Product = new ObservableCollection<ProductModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());



            MessagingCenter.Subscribe<StockEditPage, StockModel>(this, "UpdateStock", async (obj, item) =>
            {
                var updatedItem = item as StockModel;

                updatedItem.CreatedDate = DateTime.Now;
                updatedItem.UpdatedDate = DateTime.Now;
                await StockService.UpdateItemAsync(updatedItem);
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
                    if (item.IsActive)
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
