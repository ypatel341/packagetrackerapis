using Microsoft.AspNet.Identity;
using PackageTrackerAPI.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using static PackageTrackerAPI.Models.PackageDisplayModels;
using static PackageTrackerAPI.Models.PackageResponseModels;


namespace PackageTrackerAPI.Controllers
{
    [RoutePrefix("api/FullPackage")]
    public class FullPackagesController : ApiController
    {
        /* what to show on the UI
            Barcode , Courier, shipper, zip code, state, comments,
            Package Image (we can worry about after)
            Date Received, Ordered by, city, country

            models affected

            map out: Packages Entity- Barecode, Package_image, Create_Date, DepartmentKarykar
            Courier Entity- Courier_name
            Shipper Entity- Shipper_name
            Address Entity- Zip code, state, city, Country
            */

        private PackageTrackerDBEntities db = new PackageTrackerDBEntities();

        [ResponseType(typeof(Package))]
        [Route("")]
        public IHttpActionResult Getmore()
        {
            PackageDetails packagedetails = new PackageDetails();

            return Ok(db
                .Packages
                .Select(x => new PackageDetails
                {
                    //package image causes API call to take up to 1 minute
                    //packageimage = x.Package_Image,
                    barcode = x.BarCode,
                    comments = x.Comments,
                    createdate = x.Create_Date,
                    couriername = x.Courier.Courier_Name,
                    shippername = x.Shipper.Shipper_Name,
                    address1 = x.Shipper.Address.Address_Line1,
                    address2 = x.Shipper.Address.Address_Line2,
                    address3 = x.Shipper.Address.Address_Line3,
                    city = x.Shipper.Address.City,
                    state = x.Shipper.Address.StateProvince.Name,
                    country = x.Shipper.Address.Country.Name,
                    departmentkaryakar = x.Department_Karyakar.Karyakar_Name
                }));
        }

        [ResponseType(typeof(Package))]
        [Route("Details")]
        public IHttpActionResult GetDetails(string id)
        {
            PackageDetails packagedetails = new PackageDetails();
            var packagelist = db
                .Packages
                .Select(x => new PackageDetails
                {
                    //package image causes API call to take up to 1 minute
                    //packageimage = x.Package_Image,
                    barcode = x.BarCode,
                    comments = x.Comments,
                    createdate = x.Create_Date,
                    couriername = x.Courier.Courier_Name,
                    shippername = x.Shipper.Shipper_Name,
                    address1 = x.Shipper.Address.Address_Line1,
                    address2 = x.Shipper.Address.Address_Line2,
                    address3 = x.Shipper.Address.Address_Line3,
                    city = x.Shipper.Address.City,
                    state = x.Shipper.Address.StateProvince.Name,
                    country = x.Shipper.Address.Country.Name,
                    departmentkaryakar = x.Department_Karyakar.Karyakar_Name
                });

            var finalpackage = packagelist.Where(i => i.barcode == id);
            if (finalpackage == null)
            {
                return NotFound();
            }
            return Ok(finalpackage);
        }

        [HttpPost]
        [Route("New")]
        public HttpResponseMessage Post(PackageDetails package)
        {
            var entity = db.Packages.FirstOrDefault(x => x.BarCode == package.barcode);

            if (entity == null)
            {
                Package packageinsert = new Package();
                packageinsert.BarCode = package.barcode;
                packageinsert.Comments = package.comments;
                packageinsert.Create_Date = DateTime.Now;
                packageinsert.Package_Received_By = package.recievedby;
                packageinsert.Date_Received = package.createdate;

                //create method to handle new insert
                if (db.Couriers.Any(e => e.Courier_Name == package.couriername))
                {
                    var couriername = db.Couriers.FirstOrDefault(c => c.Courier_Name == package.couriername);
                    packageinsert.Courier_ID = couriername.Courier_ID;
                }
                else {
                    handlenew();
                }

                //create method to handle new insert
                if (db.Shippers.Any(e => e.Shipper_Name == package.shippername))
                {
                    var shippername = db.Shippers.FirstOrDefault(c => c.Shipper_Name == package.shippername);
                    packageinsert.Shipper_ID = shippername.Shipper_ID;
                }

                // create method to handle new insert
                if (db.Department_Karyakar.Any(e => e.Karyakar_Name == package.departmentkaryakar))
                {
                    var karykarname = db.Department_Karyakar.FirstOrDefault(c => c.Karyakar_Name == package.departmentkaryakar);
                    packageinsert.Department_Karyakar_ID = karykarname.Department_Karyakar_ID;
                }

                db.Packages.Add(packageinsert);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Accepted);

                //aready doing and processing this part
                //{
                //    "recievedby": "yogi",
                //    "couriername": "UPS",
                //    "comments": "this is a quick test",
                //    "barcode": "1ZY8A37qwerqwerqwer",

                // app code should generate this
                //    "createdate": "2016-07-03T17:36:25.473",

                // check for some sort of karykar name
                //	  "karykarid": "1",
                //    "departmentkaryakar": "Yatin test Patel",

                // check for some sort of shipper id
                //	  "shipperid":"24",
                //    "shippername": "yatin",
                //    "address1": "123 test dr",
                //    "address2": null,
                //    "address3": null,
                //    "zipcode": null,
                //    "city": "tst",
                //    "state": "New Jersey",
                //    "country": "United States",

                //    "image": null
                //}
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPut]
        [Route("Update")]
        public HttpResponseMessage Put(string id, [FromBody]PutPackageDetails package)
        {
            var entity = db.Packages.FirstOrDefault(x => x.BarCode == id);
            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest + "a package with this barcode does not exist in the system");
            }
            else
            {
                Package packageinsert = new Package();
                packageinsert.BarCode = package.barcode;
                packageinsert.Comments = package.comments;
                // packageinsert.Package_Received_By = package.recievedby;
                
                //create method to handle new insert
                if (db.Couriers.Any(e => e.Courier_Name == package.couriername))
                {
                    var couriername = db.Couriers.FirstOrDefault(c => c.Courier_Name == package.couriername);
                    packageinsert.Courier_ID = couriername.Courier_ID;
                }
                
                if (db.Delivers.Any(e => e.Recipient_Signature == package.signature))
                {
                    var signaturename = db.Delivers.FirstOrDefault(c => c.Recipient_Signature == package.signature);

                }

                //create method to handle new insert
                if (db.Shippers.Any(e => e.Shipper_Name == package.shippername))
                {
                    var shippername = db.Shippers.FirstOrDefault(c => c.Shipper_Name == package.shippername);
                    packageinsert.Shipper_ID = shippername.Shipper_ID;
                }

                // create method to handle new insert
                if (db.Department_Karyakar.Any(e => e.Karyakar_Name == package.departmentkaryakar))
                {
                    var karykarname = db.Department_Karyakar.FirstOrDefault(c => c.Karyakar_Name == package.departmentkaryakar);
                    packageinsert.Department_Karyakar_ID = karykarname.Department_Karyakar_ID;
                }

                db.Packages.Add(packageinsert);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.Accepted);
            }
        }

        public string handlenew()
        {
            return "hello";
        }
    }
}