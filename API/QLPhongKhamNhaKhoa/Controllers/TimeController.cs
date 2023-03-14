using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using BLL.Interfaces;

namespace APIPKNhaKhoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        private ITimeBusiness _timeBusiness;

        public TimeController(ITimeBusiness timeBusiness)
        {
            _timeBusiness = timeBusiness;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public TimeModel GetDatabyID(string id)
        {
            return _timeBusiness.GetTimeID(id);
        }
    }
}
