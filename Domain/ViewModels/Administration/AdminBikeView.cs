using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.ViewModels.Administration
{
    public class AdminBikeView
    {
        public Bike Bike { get; set; }
        public List<HttpPostedFileBase> Images { get; set; }

        public AdminBikeView(Bike bike)
        {
            Bike = bike;
        }
    }
}