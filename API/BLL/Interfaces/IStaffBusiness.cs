using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL.Interfaces
{
     public interface IStaffBusiness
    {
        StaffModel Authenticate(string username, string password);
        StaffModel GetStaffbyID(int id);
        List<StaffModel> GetStaff();
        bool Create(StaffModel model);
        bool Update(StaffModel model);
        bool Delete(int id);
        List<StaffModel> Search(int pageIndex, int pageSize, out long total, string staffName);
    }
}
