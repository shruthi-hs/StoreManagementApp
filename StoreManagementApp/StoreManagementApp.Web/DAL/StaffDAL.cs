using Microsoft.EntityFrameworkCore;
using StoreManagementApp.DAL.Interface;
using StoreManagementApp.Web.Models.DBContext;
using StoreManagementApp.DAL.Interface;
using StoreManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystem.DAL
{
    public class StaffDAL : IStaffDAL
    {
        private readonly InventoryDBContext _inventoryDBContext;

        public StaffDAL(InventoryDBContext inventoryDBContext)
        {
            _inventoryDBContext = inventoryDBContext;
        }

        public async Task<Staff> AddStaff(Staff staff)
        {
            try
            {
                if (staff != null)
                {
                    await _inventoryDBContext.Staffs.AddRangeAsync(staff);
                    await _inventoryDBContext.SaveChangesAsync();
                    return staff;
                }
                return staff;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteStaff(int staffId)
        {
            var deleteStaff = await _inventoryDBContext.Staffs.Where(x => x.StaffId == staffId).FirstOrDefaultAsync();

            if (deleteStaff != null)
            {
                _inventoryDBContext.Staffs.Remove(deleteStaff);
                await _inventoryDBContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Staff> EditStaff(Staff staff)
        {
            Staff existingStaff = await _inventoryDBContext.Staffs.Where(temp => temp.StaffId == staff.StaffId).FirstOrDefaultAsync();

            if (existingStaff != null)
            {
                existingStaff.Firstname = staff.Firstname;
                existingStaff.Lastname = staff.Lastname;
                existingStaff.Email = staff.Email;
                existingStaff.Phone = staff.Phone;
                existingStaff.Department = staff.Department;
                existingStaff.UpdatedDate = DateTime.Now;
                _inventoryDBContext.SaveChanges();

                return existingStaff;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Staff>> GetStaff()
        {
            return await _inventoryDBContext.Staffs.ToListAsync();
        }

    }
}
