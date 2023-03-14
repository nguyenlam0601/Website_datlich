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
    public class DoctorBusiness :IDoctorBusiness
    {
        private IDoctorRepository _res;
        public DoctorBusiness(IDoctorRepository doctorRepository)
        {
            _res = doctorRepository;
        }
        public DoctorModel GetDoctorbyID(string id)
        {
            return _res.GetDoctorbyID(id);
        }
        public List<DoctorModel> GetDoctor()
        {
            return _res.GetDoctor();
        }
        public bool Create(DoctorModel model)
        {
            return _res.Create(model);
        }
        public bool Update(DoctorModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public List<DoctorModel> Search(int pageIndex, int pageSize, out long total, string doctorID, string doctorName, string positionName)
        {
            return _res.Search(pageIndex, pageSize, out total, doctorID,doctorName,positionName);
        }
    }
}
