using StoreManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace StoreManagementApp.ViewModels
{
    public class ProductDetailViewModel : BaseViewModel
    {
        public ProductModel product { get; set; }

        public Command EditProductCommand { get; set; }




        bool isEdit = false;
        public bool IsEdit
        {
            get { return isEdit; }
            set { SetProperty(ref isEdit, value); }
        }

        bool isDetail = true;
        public bool IsDetail
        {
            get { return isDetail; }
            set { SetProperty(ref isDetail, value); }
        }


        public ProductDetailViewModel(ProductModel item = null)
        {
            IsEdit = false;
            IsDetail = true;

            Title = item?.ProductName;
            product = item;

            EditProductCommand = new Command(() => { IsEdit = true; IsDetail = false; });
        }
    }
}