using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL.Interfaces;
using DAL.Helper;

namespace DAL
{
    public partial class AppointmentRepository:IAppointmentRepository
    {
        private IDatabaseHelper _dbHelper;
        public AppointmentRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public bool Create(AppointmentModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "Create_appointment",
                 "@cusName", model.cusName,
                "@phone", model.phone,
                "@address", model.address,
                "@birthDay", model.birthDay,
                "@gender", model.gender,
                "@email", model.email,
                "@doctorId", model.doctorId,
                "@dateBooking", model.dateBooking,
                "@timeId", model.timeId);

                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
