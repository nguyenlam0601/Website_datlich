using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using BLL.Interfaces;
using DAL.Interfaces;
namespace BLL
{
    public class AppointmentBusiness:IAppointmentBusiness
    {
        private IAppointmentRepository _res;
        public AppointmentBusiness(IAppointmentRepository appointmentRepository)
        {
            _res = appointmentRepository;
        }
        public bool Create(AppointmentModel model)
        {
            return _res.Create(model);
        }
    }
}
