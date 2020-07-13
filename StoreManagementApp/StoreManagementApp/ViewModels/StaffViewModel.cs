using StoreManagementApp.Models;
using StoreManagementApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace StoreManagementApp.ViewModels
{
    public class StaffViewModel : BaseViewModel
    {
        public ObservableCollection<StaffModel> StaffMembers { get; set; }
        public Command LoadItemsCommand { get; set; }

        public Command StaffClicked { get; set; }

        public StaffViewModel()
        {
            Title = "Staff Management";
            StaffMembers = new ObservableCollection<StaffModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewStaffPage, StaffModel>(this, "AddStaff", async (obj, item) =>
            {
                var newItem = item as StaffModel;
                StaffMembers.Add(newItem);
                await StaffService.AddItemAsync(newItem);
            });


            MessagingCenter.Subscribe<StaffDetailPage, StaffModel>(this, "UpdateStaff", async (obj, item) =>
            {
                var updatedItem = item as StaffModel;
                await StaffService.UpdateItemAsync(updatedItem);
            });

            MessagingCenter.Subscribe<StaffDetailPage, StaffModel>(this, "DeleteStaff", async (obj, item) =>
            {
                var deleteItem = item as StaffModel;
                await StaffService.DeleteItemAsync(deleteItem.StaffId);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                StaffMembers.Clear();
                var items = await StaffService.GetStaffsAsync(true);
                foreach (var item in items)
                {
                    StaffMembers.Add(item);
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
