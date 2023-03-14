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
    public class BookingController : ControllerBase
    {
        private IBookingBusiness _bookingBusiness;

        public BookingController(IBookingBusiness bookingBusiness)
        {
            _bookingBusiness = bookingBusiness;
        }
        [Route("update-confirm")]
        [HttpPost]
        public BookingModel UpdateConfirm([FromBody] BookingModel model)
        {
            _bookingBusiness.UpdateConfirm(model);
            return model;
        }
        [Route("update-done")]
        [HttpPost]
        public BookingModel UpdateDone([FromBody] BookingModel model)
        {
            _bookingBusiness.UpdateDone(model);
            return model;
        }
        [Route("update-cancel")]
        [HttpPost]
        public BookingModel UpdateCancel([FromBody] BookingModel model)
        {
            _bookingBusiness.UpdateCancel(model);
            return model;
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
                long total = 0;
                var data = _bookingBusiness.Search(page, pageSize, out total);
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
        [Route("search-confirm")]
        [HttpPost]
        public ResponseModel SearchConfirm([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                long total = 0;
                var data = _bookingBusiness.SearchConfirm(page, pageSize, out total);
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
        [Route("search-done")]
        [HttpPost]
        public ResponseModel SearchDone([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                long total = 0;
                var data = _bookingBusiness.SearchDone(page, pageSize, out total);
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
        [Route("search-cancel")]
        [HttpPost]
        public ResponseModel SearchCancel([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                //DateTime dateBooking = formData.Keys.Contains("dateBooking") ? DateTime.Parse(formData["dateBooking"].ToString()) : DateTime.Now;
                //if (formData.Keys.Contains("dateBooking") && !string.IsNullOrEmpty(Convert.ToString(formData["dateBooking"])))
                //{ dateBooking = Convert.ToDateTime(formData["dateBooking"]); }
                long total = 0;
                var data = _bookingBusiness.SearchCancel(page, pageSize, out total);
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
