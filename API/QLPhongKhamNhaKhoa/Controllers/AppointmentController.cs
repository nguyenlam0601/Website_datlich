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
    public class AppointmentController : ControllerBase
    {
        private IAppointmentBusiness _appointmentBusiness;

        public AppointmentController(IAppointmentBusiness appointmentBusiness)
        {
            _appointmentBusiness = appointmentBusiness;
        }
        [Route("create-appointment")]
        [HttpPost]
        public AppointmentModel CreateAppointment([FromBody] AppointmentModel model)
        {
            _appointmentBusiness.Create(model);
            return model;
        }
    }
}
