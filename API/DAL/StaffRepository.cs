using System;
using Model;
using DAL.Helper;
using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;

namespace DAL
{
    public partial class StaffRepository:IStaffRepository
    {
        private IDatabaseHelper _dbHelper;
        public StaffRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public StaffModel GetTaiKhoan(string userName,string passWord)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Get_Taikhoan",
                     "@userName",userName,
                     "@passWord",passWord);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<StaffModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public StaffModel GetStaffbyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Get_staff_ID",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<StaffModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<StaffModel> GetStaff()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Get_all_staff");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<StaffModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(StaffModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "Create_staff",
                "@name", model.staffName,
                "@phone", model.phone,
                "@address", model.address,
                "@position", model.position,
                "@gender", model.gender,
                "@birthDay",model.birthDay,
                "@email",model.email,
                "@loaiQuyen",model.loaiQuyen);
               
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
        public bool Update(StaffModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "Update_staff",
                 "@id",model.id,
                //"@staffID", model.StaffID,
                "@name", model.staffName,
                "@phone", model.phone,
                "@address", model.address,
                "@position", model.position,
                "@gender", model.gender,
                "@birthDay", model.birthDay,
                "@email", model.email,
                "@loaiQuyen", model.loaiQuyen);
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
        public bool Delete(int id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "Delete_staff",
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
        public List<StaffModel> Search(int pageIndex, int pageSize, out long total, string staffName)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "search_staff",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@name", staffName,
                    "@total",total);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<StaffModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
