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
    public partial class NewStaffPage : ContentPage
    {
        public StaffModel staff { get; set; }
        public NewStaffPage()
        {
            InitializeComponent();
            staff = new StaffModel();
            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            staff.CreatedDate = DateTime.Now;
            staff.UpdatedDate = DateTime.Now;
            MessagingCenter.Send(this, "AddStaff", staff);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}