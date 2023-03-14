﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL.Interfaces
{
    public interface IScheduleRepository
    {
        List<ScheduleModel> Search(int pageIndex, int pageSize, out long total, string doctorID, string currentNumber);
        ScheduleModel GetScheduleID(int id);
    }
}
