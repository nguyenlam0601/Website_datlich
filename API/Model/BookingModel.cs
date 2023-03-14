using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BookingModel
    {
        public int id { get; set; }
        public string doctorId { get; set; }
        public int customerId { get; set; }
        public string dateBooking { get; set; }
        public string timeId { get; set; }
        public int status { get; set; }
        public string timeValue { get; set; }
        public string cusName { get; set; }
        public Boolean gender { get; set; }
        public string address { get; set; }
        public DateTime? birthDay { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string docName { get; set; }

    }
}
