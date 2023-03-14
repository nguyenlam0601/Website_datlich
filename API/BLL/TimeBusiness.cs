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
    public class TimeBusiness:ITimeBusiness
    {
        private ITimeRepository _res;
        public TimeBusiness(ITimeRepository timeRepository)
        {
            _res = timeRepository;
        }
        public TimeModel GetTimeID(string id)
        {
            return _res.GetTimeID(id);
        }
    }
}
