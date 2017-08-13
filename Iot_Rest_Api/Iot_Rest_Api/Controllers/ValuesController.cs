using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Iot_Rest_Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        private DataRepository _datarepository; 

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{status}")]
        public string UpdateMeetingRoomStatus(string status)
        {
            _datarepository = new DataRepository();
            var result = GetIdAndStatusSeperated(status);
            _datarepository.UpdateMeetingRoomStatus(result[0], result[1]);
            return "done";
        }

        private int[] GetIdAndStatusSeperated(string input)
        {
            string[] words = input.Split('-');
            var id = Convert.ToInt16(words[0]);
            var status = Convert.ToInt16(words[1]);
            return new int[] { id,status};
        }
    }
}
