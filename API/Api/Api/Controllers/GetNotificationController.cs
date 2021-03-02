using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api/GetNotification")]
    public class GetNotificationController : ApiController
    {

        OTP.SWAPIClient objW = new OTP.SWAPIClient();
        [HttpPost]
        [Route("Post")]
        public IHttpActionResult Post(Param code)
        {
            List<OTP.notification> values = objW.mGetAppsNotifucation("0003", code.strtc).ToList();
            return Json(values);
        }

        public class Param
        {
            public string strtc { get; set; }

        }
    }
}
