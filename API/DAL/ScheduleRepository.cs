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
    public partial class ScheduleRepository:IScheduleRepository
    {
        private IDatabaseHelper _dbHelper;
        public ScheduleRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public ScheduleModel GetScheduleID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Get_schedule_ID",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ScheduleModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ScheduleModel> Search(int pageIndex, int pageSize, out long total,string doctorID, string currentNumber)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "search_schedule",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@doctorID", doctorID,
                    "@currentNumber", currentNumber,
                    "@total", total);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<ScheduleModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
