using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL.Interfaces
{
    public interface IBookingBusiness
    {
        bool UpdateConfirm(BookingModel model);
        bool UpdateDone(BookingModel model);
        bool UpdateCancel(BookingModel model);
        List<BookingModel> Search(int pageIndex, int pageSize, out long total);
        List<BookingModel> SearchDone(int pageIndex, int pageSize, out long total);
        List<BookingModel> SearchConfirm(int pageIndex, int pageSize, out long total);
        List<BookingModel> SearchCancel(int pageIndex, int pageSize, out long total);

    }
}
