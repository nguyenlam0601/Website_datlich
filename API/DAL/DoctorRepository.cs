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
    public partial class DoctorRepository : IDoctorRepository
    {
        private IDatabaseHelper _dbHelper;
        public DoctorRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public DoctorModel GetDoctorbyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Get_doctor_ID",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DoctorModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DoctorModel> GetDoctor()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Get_all_doctor");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DoctorModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(DoctorModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "Create_doctor",
                 "@id", model.id,
                "@name", model.docName,
                "@phone", model.phone,
                "@address", model.address,               
                "@birthDay", model.birthDay,
                "@gender", model.gender,
                "@email", model.email,
                "@price", model.price,
                "@avatar", model.avatar,
                "@positionId", model.positionId,
                "@description",model.Description);

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
        public bool Update(DoctorModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "Update_doctor",
                 "@id", model.id,
                "@name", model.docName,
                "@phone", model.phone,
                "@address", model.address,
                "@birthDay", model.birthDay,
                "@gender", model.gender,
                "@email", model.email,
                "@price", model.price,
                "@avatar", model.avatar,
                "@positionId", model.positionId,
                "@description", model.Description);
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
        public bool Delete(string id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "Delete_doctor",
                "@id", id);
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
        public List<DoctorModel> Search(int pageIndex, int pageSize, out long total, string doctorID, string doctorName, string positionName)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "search_doctor",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@id",doctorID,
                    "@name", doctorName,
                    "@position",positionName,
                    "@total", total);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<DoctorModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
