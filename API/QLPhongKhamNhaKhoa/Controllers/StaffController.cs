using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using BLL;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace QLPhongKhamNhaKhoa.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private IStaffBusiness _staffBusiness;

        public StaffController(IStaffBusiness staffBusiness)
        {
            _staffBusiness = staffBusiness;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var user = _staffBusiness.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public StaffModel GetDatabyID(int id)
        {
            return _staffBusiness.GetStaffbyID(id);
        }
        [Route("get-staff")]
        [HttpGet]
        public List<StaffModel> GetData()
        {
            return _staffBusiness.GetStaff();
        }
        [Route("create-staff")]
        [HttpPost]
        public StaffModel CreateStaff([FromBody] StaffModel model)
        {
            _staffBusiness.Create(model);
            return model;
        }
        [Route("update-staff")]
        [HttpPost]
        public StaffModel UpdateStaff([FromBody] StaffModel model)
        {
            _staffBusiness.Update(model);
            return model;
        }
        [Route("delete-staff/{id}")]
        [HttpDelete]
        public IActionResult DeleteStaff(int id)
        {   
            _staffBusiness.Delete(id);
            return Ok();
        }
        [Route("search")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string staffName = "";
                if (formData.Keys.Contains("staffName") && !string.IsNullOrEmpty(Convert.ToString(formData["staffName"])))
                { staffName = Convert.ToString(formData["staffName"]); }
                long total = 0;
                var data = _staffBusiness.Search(page, pageSize, out total, staffName);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
    }
}
