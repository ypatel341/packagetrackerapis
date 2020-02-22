using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackageTrackerAPI.Models
{
    public class PackageResponseModels
    {
        public class PackageGeneric
        {
            public int packageid { get; set; }
            public string barcode { get; set; }
            public string comments { get; set; }
            public DateTime? daterecieved { get; set; }
            public DateTime createdate { get; set; }
            public byte[] packageimage { get; set; }
            public int departmentkaryakarID { get; set; }
            public int shipperID { get; set; }
            public int courerID { get; set; }
            //public IEnumerable<Receivers> receiverlist {get; set;}
            public IEnumerable<Delivers> deliverlist { get; set; }
            public IEnumerable<Shippers> shipperlist { get; set; }

        }

        public class Addresses
        {
            public int addressID { get; set; }
            public int? stateID { get; set; }
            public int? countryID { get; set; }
            public string addressline1 { get; set; }
            public string addressline2 { get; set; }
            public string addressline3 { get; set; }
            public string city { get; set; }
            public string zipcode { get; set; }
            public string createDate { get; set; }
        }

        public class Shippers
        {
            public int ShipperID { get; set; }
            public int AddressID { get; set; }
            public DateTime createdate { get; set; }
            public string shippername { get; set; }
            public string shippercompany { get; set; }
        }

        public class States
        {
            public int countryID { get; set; }
            public string name { get; set; }
            public string abbreviation { get; set; }
        }

        public class Countries
        {
            public int countryID { get; set; }
            public string  countryabb { get; set; }
            public string name { get; set; }
        }


        public class Couriers
        {
            public int courierID { get; set; }
            public string couriername { get; set; }
            public DateTime courierDT { get; set; }
        }

        public class Receivers
        {
            public int packageid { get; set; }
            public string recieverName { get; set; }
            public string signature { get; set; }
            public string recieverComments { get; set; }
        }

        public class Delivers
        {
            public int packageid { get; set; }
            public string karykarName { get; set; }
            public string karykarSign { get; set; }
            public DateTime? delDate { get; set; }
        }

        public class Karyakars
        {
            public string name { get; set; }
            public string email { get; set; }
        }
    }
}