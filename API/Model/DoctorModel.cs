using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DoctorModel
    {
        public string id { get; set; }
        public string docName { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public DateTime? birthDay { get; set; }
        public Boolean gender { get; set; }
        public string email { get; set; }
        public float price { get; set; }
        public string avatar { get; set; }
        public string positionId { get; set; }
        public string positionName { get; set; }
        public string Description { get; set; }
    }
}
