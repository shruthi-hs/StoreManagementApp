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
    public partial class StaffDetailPage : ContentPage
    {
        StaffDetailViewModel viewModel;
       
        public StaffDetailPage(StaffDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        public StaffDetailPage()
        {
            InitializeComponent();

            var item = new StaffModel
            {
                FirstName = "first name",
                Lastname = "last name",
                Email="email",
                Phone="phone",
                Department = "department"
            };

            viewModel = new StaffDetailViewModel(item);
            BindingContext = viewModel;
        }

        async void UpdateStaff_Clicked(object sender, EventArgs e)
        {
            var item = viewModel.staff;
            item.CreatedDate = DateTime.Now;
            item.UpdatedDate = DateTime.Now;
            MessagingCenter.Send(this, "UpdateStaff", item);
            await Navigation.PopModalAsync();
        }

        async void DeleteStaff_Clicked(object sender, EventArgs e)
        {
            var item = viewModel.staff;
            MessagingCenter.Send(this, "DeleteStaff", item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

    }
}