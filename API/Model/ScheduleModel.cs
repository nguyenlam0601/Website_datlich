using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ScheduleModel
    {
        public int id { get; set; }
        public string currentNumber { get; set; }
        public string timeId { get; set; }
        public string doctorId { get; set; }
        public string timeValue { get; set; }
    }
}
