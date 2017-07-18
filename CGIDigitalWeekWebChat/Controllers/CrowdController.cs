using CGIDigitalWeekWebChat.Models;
using System.Linq;
using System.Web.Http;

namespace CGIDigitalWeekWebChat.Controllers
{
    public class CrowdController : ApiController
    {
        [Route("Crowd/StandsInfo/{standId}")]
        public IHttpActionResult GetStandsInfo(string standId)
        {
            var headers = Request.Headers;
            if (headers.Contains("Auth") && headers.GetValues("Auth").First() == "CGIDigitalWeek")
            {
                var personCount = CrowdModels.GetStandsOccupation(standId);
                if (!personCount.HasValue)
                {
                    return NotFound();
                }
                return Ok(personCount.Value);
            }
            else
            {
                return Unauthorized();
            }
        }

        [Route("Crowd/StandsInfo")]
        public IHttpActionResult GetStandsInfo()
        {
            var headers = Request.Headers;
            if (headers.Contains("Auth") && headers.GetValues("Auth").First() == "CGIDigitalWeek")
            {
                var standsInfo = CrowdModels.GetStandsInfo();
                return Json(standsInfo);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}