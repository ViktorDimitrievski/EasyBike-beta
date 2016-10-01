using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.ViewModels.Administration
{
    public class AdminBikesView
    {
        public List<Bike> Bikes { get; set; }


        public AdminBikesView()
        {
            Bikes = new List<Bike>();
        }

        public AdminBikesView(List<Bike> _bikes)
        {
            Bikes = _bikes;
        }
    }
}