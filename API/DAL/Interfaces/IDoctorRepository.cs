using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL.Interfaces
{
    public interface IDoctorRepository
    {
    
        DoctorModel GetDoctorbyID(string id);
        List<DoctorModel> GetDoctor();
        bool Create(DoctorModel model);
        bool Update(DoctorModel model);
        bool Delete(string id);
        List<DoctorModel> Search(int pageIndex, int pageSize, out long total, string doctorID,string doctorName,string positionName);
    }
}
