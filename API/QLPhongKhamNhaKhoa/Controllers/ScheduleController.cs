using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using BLL;
using BLL.Interfaces;

namespace APIPKNhaKhoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private IScheduleBusiness _scheduleBusiness;

        public ScheduleController(IScheduleBusiness doctorBusiness)
        {
            _scheduleBusiness = doctorBusiness;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public ScheduleModel GetDatabyID(int id)
        {
            return _scheduleBusiness.GetScheduleID(id);
        }
        [Route("search")]
        [HttpPost]
        public ResponseModel SearchCancel([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string doctorID = "";
                if (formData.Keys.Contains("doctorID") && !string.IsNullOrEmpty(Convert.ToString(formData["doctorID"])))
                { doctorID = Convert.ToString(formData["doctorID"]); }
                string currentNumber = formData["currentNumber"].ToString();
                long total = 0;
                var data = _scheduleBusiness.Search(page, pageSize, out total, doctorID, currentNumber);
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
