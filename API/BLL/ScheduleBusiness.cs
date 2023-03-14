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
    public class ScheduleBusiness:IScheduleBusiness
    {
        private IScheduleRepository _res;
        public ScheduleBusiness(IScheduleRepository scheduleRepository)
        {
            _res = scheduleRepository;
        }
        public ScheduleModel GetScheduleID(int id)
        {
            return _res.GetScheduleID(id);
        }
        public List<ScheduleModel> Search(int pageIndex, int pageSize, out long total, string doctorID, string currentNumber)
        {
            return _res.Search(pageIndex, pageSize, out total, doctorID, currentNumber);
        }
    }
}
