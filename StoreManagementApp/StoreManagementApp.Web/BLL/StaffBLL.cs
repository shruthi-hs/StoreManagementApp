using StoreManagementApp.BLL.Interface;
using StoreManagementApp.DAL.Interface;
using StoreManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace StoreManagementApp.BLL
{
    public class StaffBLL : IStaffBLL
    {
        private readonly IStaffDAL _staffDAL;

        public StaffBLL(IStaffDAL staffDAL)
        {
            _staffDAL = staffDAL;
        }
        public async Task<List<Staff>> GetStaff()
        {
            return await _staffDAL.GetStaff();
        }

        public async Task<Staff> AddStaff(Staff newStaff)
        {
            Staff staff;

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    staff = await _staffDAL.AddStaff(newStaff);
                    scope.Complete();

                }
                catch (Exception)
                {
                    staff = null;
                    throw;
                }
            }
            return staff;
        }


        public async Task<bool> DeleteStaff(int staffId)
        {
            bool status = false;

            if (staffId > 0)
                status = await _staffDAL.DeleteStaff(staffId);

            return status;
        }

        public async Task<Staff> EditStaff(Staff staff)
        {
            return await _staffDAL.EditStaff(staff);
        }



    }
}
