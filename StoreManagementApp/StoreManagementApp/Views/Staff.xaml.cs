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
    public partial class Staff : ContentPage
    {
        StaffViewModel viewModel;
        public Staff()
        {
            InitializeComponent();

            BindingContext = viewModel = new StaffViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.StaffMembers.Count == 0)
                viewModel.IsBusy = true;
        }

        async void View_Clicked(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var item = (StaffModel)layout.BindingContext;
            await Navigation.PushModalAsync(new NavigationPage(new StaffDetailPage(new StaffDetailViewModel(item))));
        }


        async void AddStaff_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewStaffPage()));
        }
    }
}