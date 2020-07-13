using StoreManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagementApp.Services
{
    public interface IStaffService
    {
        Task<IEnumerable<StaffModel>> GetStaffsAsync(bool forceRefresh = false);

        Task<StaffModel> AddItemAsync(StaffModel staff);

        Task<StaffModel> UpdateItemAsync(StaffModel staff);

        Task<bool> DeleteItemAsync(int staffId);
    }
}
