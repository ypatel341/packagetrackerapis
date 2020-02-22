using PackageTrackerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using static PackageTrackerAPI.Models.PackageResponseModels;

namespace PackageTrackerAPI.Controllers
{
    [RoutePrefix("api/Barcode")]
    public class BarcodeController : ApiController
    {
        private PackageTrackerDBEntities db = new PackageTrackerDBEntities();

        [ResponseType(typeof(Package))]
        [Route("")]
        public IHttpActionResult Get(string id)
        {
            var packagelist = db
                .Packages
                .Select(x => new PackageGeneric
                {
                    packageid = x.Package_ID,
                    barcode = x.BarCode,
                    comments = x.Comments
                }).ToList();

            var finalpackage = packagelist.Where(i => i.barcode == id);
            if (finalpackage == null)
            {
                return NotFound();
            }
            return Ok(finalpackage);
        }


        [ResponseType(typeof(Package))]
        [Route("full")]
        public IHttpActionResult Getmore(string id)
        {
            var packagelist = db
                .Packages
                .Include("Deliver")
                .Select(x => new PackageGeneric
                {
                    packageid = x.Package_ID,
                    barcode = x.BarCode,
                    comments = x.Comments,
                    daterecieved = x.Date_Received,
                    createdate = x.Create_Date,
                    deliverlist = x.Delivers.Select(d => new Delivers
                    {
                        packageid = d.Package_ID,
                        karykarName = d.Karyakar_Name,
                        karykarSign = d.Karyakar_Signature,
                        delDate = d.Delivery_Date
                    }).ToList()
                }).ToList();


            var finalpackage = packagelist.Where(i => i.barcode == id);
            if (finalpackage == null)
            {
                return NotFound();
            }
            return Ok(finalpackage);
        }
    }
}
