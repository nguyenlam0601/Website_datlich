using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using BLL.Interfaces;

namespace APIPKNhaKhoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private IDoctorBusiness _doctorBusiness;

        public DoctorController(IDoctorBusiness doctorBusiness)
        {
            _doctorBusiness = doctorBusiness;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public DoctorModel GetDatabyID(string id)
        {
            return _doctorBusiness.GetDoctorbyID(id);
        }
        [Route("get-doctor")]
        [HttpGet]
        public List<DoctorModel> GetData()
        {
            return _doctorBusiness.GetDoctor();
        }
        [Route("create-doctor")]
        [HttpPost]
        public DoctorModel CreateDoctor([FromBody] DoctorModel model)
        {
            _doctorBusiness.Create(model);
            return model;
        }
        [Route("update-doctor")]
        [HttpPost]
        public DoctorModel UpdateDoctor([FromBody] DoctorModel model)
        {
            _doctorBusiness.Update(model);
            return model;
        }
        [Route("delete-doctor/{id}")]
        [HttpDelete]
        public IActionResult DeleteDoctor(string id)
        {
            _doctorBusiness.Delete(id);
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
                string doctorID = "";
                if (formData.Keys.Contains("doctorID") && !string.IsNullOrEmpty(Convert.ToString(formData["doctorID"])))
                { doctorID = Convert.ToString(formData["doctorID"]); }
                string doctorName = "";
                if (formData.Keys.Contains("doctorName") && !string.IsNullOrEmpty(Convert.ToString(formData["doctorName"])))
                { doctorName = Convert.ToString(formData["doctorName"]); }
                string positionName = "";
                if (formData.Keys.Contains("positionName") && !string.IsNullOrEmpty(Convert.ToString(formData["positionName"])))
                { positionName = Convert.ToString(formData["positionName"]); }
                long total = 0;
                var data = _doctorBusiness.Search(page, pageSize, out total, doctorID,doctorName, positionName);
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
