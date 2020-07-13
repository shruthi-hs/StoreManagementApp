using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreManagementApp.BLL.Interface;
using StoreManagementApp.DTO;
using StoreManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementApp.Controllers
{
    [ApiController]
    [Route("api/staff")]
    public class StaffController:ControllerBase
    {
        private readonly IStaffBLL _staffBLL;
        private readonly IMapper _mapper;
        public StaffController(IStaffBLL staffBLL, IMapper mapper)
        {
            _staffBLL = staffBLL;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getStaff")]
        public async Task<IActionResult> GetStaff()
        {
            List<StaffDTO> staffDTOs;
            try
            {
                List<Staff> staff = await _staffBLL.GetStaff();
                staffDTOs = _mapper.Map<List<StaffDTO>>(staff);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return base.Ok(staffDTOs);
        }


        [HttpPost]
        [Route("addStaff")]
        public async Task<IActionResult> AddStaff(StaffDTO staffDTO)
        {
            StaffDTO staffDTOResponse;
            try
            {
                Staff staff = _mapper.Map<Staff>(staffDTO);
                var response = await _staffBLL.AddStaff(staff);
                staffDTOResponse = _mapper.Map<StaffDTO>(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return base.Ok(staffDTOResponse);
        }


        [HttpPut]
        [Route("editStaff")]
        public async Task<IActionResult> EditAsset([FromBody] StaffDTO staffDTO)
        {
            StaffDTO staffDTOResponse;

            try
            {
                Staff staff = _mapper.Map<Staff>(staffDTO);
                var response = await _staffBLL.EditStaff(staff);
                staffDTOResponse = _mapper.Map<StaffDTO>(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return base.Ok(staffDTOResponse);
        }

        [HttpPut]
        [Route("deleteStaff")]
        public async Task<IActionResult> DeleteStaff(int staffId)
        {
            StaffDTO staffDTOResponse;

            try
            {
                var response = await _staffBLL.DeleteStaff(staffId);
                staffDTOResponse = _mapper.Map<StaffDTO>(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return base.Ok(staffDTOResponse);
        }
    }
}
