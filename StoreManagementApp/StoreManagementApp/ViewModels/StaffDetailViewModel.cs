using StoreManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StoreManagementApp.ViewModels
{
    public class StaffDetailViewModel : BaseViewModel
    {
        public StaffModel staff { get; set; }

        public Command EditStaffCommand { get; set; }

       


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


        public StaffDetailViewModel(StaffModel item = null)
        {
            IsEdit = false;
            IsDetail = true;

            Title = item?.FirstName;
            staff = item;

            EditStaffCommand = new Command(() => { IsEdit = true; IsDetail = false; })  ;
        }

    }
}
