using System;

namespace Model
{
    public class StaffModel
    {
        public int id { get; set; }
        public string staffName { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string position { get; set; }
        public Boolean gender { get; set; }
        public DateTime? birthDay { get; set; }
        public string email { get; set; }
        public string loaiQuyen { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }
        public string token { get; set; }
    }
}
