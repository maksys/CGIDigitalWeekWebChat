using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CGIDigitalWeekWebChat.Models;

namespace CGIDigitalWeekWebChat.Controllers
{
    public class CrowdController : ApiController
    {
        [Route("Crowd/GetPersons/{standId}")]
        public IHttpActionResult GetStandPersons(string standId)
        {
            var persons = CrowdModels.GetPersons(standId);
            if (!persons.HasValue)
            {
                return NotFound();
            }
            return Ok(persons.Value);
        }


    }
}
