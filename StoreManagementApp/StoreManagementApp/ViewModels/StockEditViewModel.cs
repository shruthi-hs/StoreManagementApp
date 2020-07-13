using StoreManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementApp.ViewModels
{
    public class StockEditViewModel : BaseViewModel
    {
        public ProductModel product { get; set; }
        public StockEditViewModel(ProductModel item = null)
        {
            Title = item?.ProductName;
            product = item;
        }
    }
}
