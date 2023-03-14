using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Interfaces;
using Model;

namespace BLL
{
   public class BookingBusiness:IBookingBusiness
    {
        private IBookingRepository _res;
        public BookingBusiness(IBookingRepository bookingRepository)
        {
            _res = bookingRepository;
        }
        public bool UpdateConfirm(BookingModel model)
        {
            return _res.UpdateConfirm(model);
        }
        public bool UpdateDone(BookingModel model)
        {
            return _res.UpdateDone(model);
        }
        public bool UpdateCancel(BookingModel model)
        {
            return _res.UpdateCancel(model);
        }
        public List<BookingModel> Search(int pageIndex, int pageSize, out long total)
        {
            return _res.Search(pageIndex, pageSize, out total);
        }
        public List<BookingModel> SearchConfirm(int pageIndex, int pageSize, out long total)
        {
            return _res.SearchConfirm(pageIndex, pageSize, out total);
        }
        public List<BookingModel> SearchDone(int pageIndex, int pageSize, out long total)
        {
            return _res.SearchDone(pageIndex, pageSize, out total);
        }
        public List<BookingModel> SearchCancel(int pageIndex, int pageSize, out long total)
        {
            return _res.SearchCancel(pageIndex, pageSize, out total);
        }
    }
}
