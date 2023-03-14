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
    public partial class TimeRepository:ITimeRepository
    {
        private IDatabaseHelper _dbHelper;
        public TimeRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public TimeModel GetTimeID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Get_time_ID",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TimeModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
