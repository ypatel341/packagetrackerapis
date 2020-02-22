using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackageTrackerAPI.Models
{
    public class PackageDisplayModels
    {
        /*
  map out: Packages Entity- Barecode, Package_image, Create_Date, DepartmentKarykar
  Courier Entity- Courier_name
  Shipper Entity- Shipper_name
  Address Entity- Zip code, state, city, Country
 */
        public class PackageDetails
        {
            public string barcode { get; set; }
            public byte[] packageimage { get; set; }
            public DateTime createdate { get; set; }
            public string departmentkaryakar { get; set; }
            public string couriername { get; set; }
            public string shippername { get; set; }
            public string address1 { get; set; }
            public string address2 { get; set; }
            public string address3 { get; set; }
            public string zipcode { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string country { get; set; }
            public string comments { get; set; }
            public byte[] image { get; set; }
            //new 11/21/17
            public string recievedby { get; set; }
            public int shipperid { get; set; }
            public int karykarid { get; set; }
        }

        public class PutPackageDetails
        {
            public string barcode { get; set; }
            public byte[] packageimage { get; set; }
            public string departmentkaryakar { get; set; }
            public string couriername { get; set; }
            public string shippername { get; set; }
            public string address1 { get; set; }
            public string address2 { get; set; }
            public string address3 { get; set; }
            public string zipcode { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string country { get; set; }
            public string comments { get; set; }
            public byte[] image { get; set; }
            //new 11/21/17
            public string recievedby { get; set; }
            public int shipperid { get; set; }
            public int karykarid { get; set; }
            public DateTime daterecieved { get; set; }
            public string signature { get; set; }
        }
    }
}