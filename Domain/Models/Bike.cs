using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Bike
    {
        public int ID { get; set; }
        public string BikeCode { get; set; }
        public string SerialNumber { get; set; }
        public double  Latitude { get; set; }
        public double Longtitude { get; set; }
        public virtual City City { get; set; }
        public int CityID { get; set; }
        public List<File> Photos { get; set; }
    }
}