using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CaptainMao.Areas.buy.Controllers
{
    public class ReportController : ApiController
    {
        // GET: api/Report
        public string Get()
        {
            return User.Identity.GetUserId();
        }
       
    }
}
