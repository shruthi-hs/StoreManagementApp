
using StoreManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementApp.DAL.Interface
{
    public interface IStaffDAL
    {
        Task<List<Staff>> GetStaff();

        Task<Staff> AddStaff(Staff staff);

        Task<Staff> EditStaff(Staff staff);

        Task<bool> DeleteStaff(int staffId);
    }
}
