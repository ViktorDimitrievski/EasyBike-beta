using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.ViewModels
{
    public class LocationViewModel
    {
        public string jsonBikes { get; set; }
        public List<City> Cities { get; set; }
        public List<Bike> Bikes{ get; set; }
        public int CityID { get; set; }


        public LocationViewModel()
        {
            Cities = new List<City>();
            Bikes = new List<Bike>();
        }
    }
}