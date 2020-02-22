using PackageTrackerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PackageTrackerAPI.Controllers
{
    public class KaryakarController : ApiController
    {
        public IHttpActionResult Get()
        {
            using (PackageTrackerDBEntities ctx = new PackageTrackerDBEntities())
            {
                var result = ctx.Department_Karyakar.Select(dk => new
                {
                    dk.Department_Karyakar_ID,
                    dk.Department_ID,
                    dk.Karyakar_Name
                });
                return Ok(result);
            }
        }
    }
}
